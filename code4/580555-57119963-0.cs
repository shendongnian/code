    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Azure.WebJobs.Extensions.Http;
    using Microsoft.Extensions.Logging;
    using Renci.SshNet;
    using Renci.SshNet.Sftp;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    
    namespace SFTPFileMonitor
    {
        public class GetListOfFiles
        {
            [FunctionName("GetListOfFiles")]
            public async Task<IActionResult> RunAsync([HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequest req, ILogger log)
            {
                log.LogInformation("C# HTTP trigger function processed a request.");
    
                List<SftpFile> zFiles;
                int fileCount;
                decimal totalSizeGB;
                long totalSizeBytes;
    
                using (SftpClient sftpClient = new SftpClient("hostname", "username", "password"))
                {
                    sftpClient.Connect();
                    zFiles = await GetFiles(sftpClient, sftpClient.WorkingDirectory, new List<SftpFile>());
                    fileCount = zFiles.Count;
                    totalSizeBytes = zFiles.Sum(l => l.Length);
                    totalSizeGB = BytesToGB(totalSizeBytes);
                }
    
                return new OkObjectResult(new { fileCount, totalSizeBytes, totalSizeGB, zFiles });
            }
            private async Task<List<SftpFile>> GetFiles(SftpClient sftpClient, string directory, List<SftpFile> files)
            {
                foreach (SftpFile sftpFile in sftpClient.ListDirectory(directory))
                {
                    if (sftpFile.Name.StartsWith('.')) { continue; }
    
                    if (sftpFile.IsDirectory)
                    {
                        await GetFiles(sftpClient, sftpFile.FullName, files);
                    }
                    else
                    {
                        files.Add(sftpFile);
                    }
                }
                return files;
            }
            private decimal BytesToGB(long bytes)
            {
                return Convert.ToDecimal(bytes) / 1024 / 1024 / 1024;
            }
        }
    }
