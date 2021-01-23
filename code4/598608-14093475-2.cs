    using System;
    using System.IO;
    using System.Threading;
    using System.Web.Mvc;
    
    namespace Mvc3Test
    {
        public class FileThrottleResult : FilePathResult
        {
            float rate = 0;
    
            /// <summary>
            /// 
            /// </summary>
            /// <param name="fileName"></param>
            /// <param name="contentType"></param>
            /// <param name="rate">Kbps</param>
            public FileThrottleResult(string fileName, string contentType, float rate)
                : base(fileName, contentType)
            {
                if (!File.Exists(fileName))
                {
                    throw new ArgumentNullException("fileName");
                }
                this.rate = rate;
            }
    
            protected override void WriteFile(System.Web.HttpResponseBase response)
            {
                int _bufferSize = (int)Math.Round(1024 * this.rate);
                byte[] buffer = new byte[_bufferSize];
    
                Stream outputStream = response.OutputStream;
    
                using (var stream = File.OpenRead(FileName))
                {
                    response.AddHeader("Cache-control", "private");
                    response.AddHeader("Content-Type", "application/octet-stream");
                    response.AddHeader("Content-Length", stream.Length.ToString());
                    response.AddHeader("Content-Disposition", String.Format("filename={0}", new FileInfo(FileName).Name));
                    response.Flush();
    
                    while (true)
                    {
                        if (!response.IsClientConnected)
                            break;
    
                        int bytesRead = stream.Read(buffer, 0, _bufferSize);
                        if (bytesRead == 0)
                            break;
    
                        outputStream.Write(buffer, 0, bytesRead);
                        response.Flush();
                        Thread.Sleep(1000);
                    }
                }
            }
        }
    }
