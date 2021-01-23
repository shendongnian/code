    using System;
    using System.Globalization;
    using System.IO;
    using System.Net.Http;
    using System.Security.Cryptography;
    
    namespace AzureSharedKey
    {
        class Program
        {
            private const string blobStorageAccount = "your_account";
            private const string blobStorageAccessKey = "your_access_key";
            private const string blobPath = "blob_path";
            private const string blobContainer = "your_container";
            static void Main(string[] args)
            {
                Console.WriteLine("Program Initiated..");
                CreateContainer();
                Console.ReadLine();
            }
            private async static void CreateContainer()
            {
                string requestMethod = "GET";
                string msVersion = "2016-05-31";
                string date = DateTime.UtcNow.ToString("R", CultureInfo.InvariantCulture);
                string clientRequestId = Guid.NewGuid().ToString();
                string canHeaders = string.Format("x-ms-client-request-id:{0}\nx-ms-date:{1}\nx-ms-version:{2}", clientRequestId, date, msVersion);
                string canResource = string.Format("/{0}/{1}/{2}", blobStorageAccount, blobContainer, blobPath);
                string SignStr = string.Format("{0}\n\n\n\n\n\n\n\n\n\n\n\n{1}\n{2}", requestMethod, canHeaders, canResource);
                string auth = CreateAuthString(SignStr);
                string urlPath = string.Format("https://{0}.blob.core.windows.net/{1}/{2}", blobStorageAccount, blobContainer, blobPath);
                Uri uri = new Uri(urlPath);
                Console.WriteLine("urlPath  "+ urlPath);
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Add("x-ms-date", date);
                client.DefaultRequestHeaders.Add("x-ms-version", "2016-05-31");
                client.DefaultRequestHeaders.Add("x-ms-client-request-id", clientRequestId);
                client.DefaultRequestHeaders.Add("Authorization", auth);
    
                HttpResponseMessage response = client.GetAsync(uri).Result;
                if (response.IsSuccessStatusCode)
                {
                    string actualFilename= Path.GetFileName(blobPath);
                    string physicaPath = "D:/Others/AZ/";//change path to where you want to write the file
                    HttpContent content = response.Content;
                    string pathName = Path.GetFullPath(physicaPath + actualFilename);
                    FileStream fileStream = null;
                    try
                    {
                        fileStream = new FileStream(pathName, FileMode.Create, FileAccess.Write, FileShare.None);
                        await content.CopyToAsync(fileStream).ContinueWith(
                           (copyTask) =>
                           {
                               fileStream.Close();
                           });
                        Console.WriteLine("FileName: "+actualFilename);
                        Console.WriteLine("File Saved Successfully..");
                    }
                    catch
                    {
                        if (fileStream != null) fileStream.Close();
                        throw;
                    }
    
                }
                else
                {
                    throw new FileNotFoundException();
                }
            }
    
            private static string CreateAuthString(string SignStr)
            {
                string signature = string.Empty;
                byte[] unicodeKey = Convert.FromBase64String(blobStorageAccessKey);
                using (HMACSHA256 hmacSha256 = new HMACSHA256(unicodeKey))
                {
                    byte[] dataToHmac = System.Text.Encoding.UTF8.GetBytes(SignStr);
                    signature = Convert.ToBase64String(hmacSha256.ComputeHash(dataToHmac));
                }
    
                string authorizationHeader = string.Format(
                      CultureInfo.InvariantCulture,
                      "{0} {1}:{2}",
                      "SharedKey",
                      blobStorageAccount,
                      signature);
    
                return authorizationHeader;
            }
        }
    }
