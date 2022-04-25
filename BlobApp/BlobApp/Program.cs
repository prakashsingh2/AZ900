using Azure.Storage.Blobs;
using System;
using System.IO;
using System.Threading.Tasks;

namespace BlobApp
{
    class Program
    {
        static string str_connection = "DefaultEndpointsProtocol=https;AccountName=storageaccountps25;AccountKey=DLKTYHTdWM+tX+TG4MhYue6bnCe5MCzWn3rebR0p3wSbd94k9nvhDfQbDp+eR/rpy4dIKSPLcbRUt70bpFddqQ==;EndpointSuffix=core.windows.net";
        static async Task Main()
        {
            BlobServiceClient blobServiceClient = new BlobServiceClient(str_connection);
            BlobContainerClient container_client = blobServiceClient.GetBlobContainerClient("data");

            BlobClient blob_client=container_client.GetBlobClient("debug.txt");
            using FileStream uploadFileStream = File.OpenRead("C:\\temp\\debug.txt");
            await blob_client.UploadAsync(uploadFileStream, true);
            uploadFileStream.Close();
            Console.WriteLine("File uploaded");

            Console.WriteLine("Operation complete");
        }
    }
}
