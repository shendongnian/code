    using System;
    using System.IO;
    using System.Net;
    namespace PhoneGapBuildQuestion
    {
        class Program
        {
            static void Main(string[] args)
            {
                string appId = "[your appId here]";
                string fileName = "[absolute path to .zip file here]";
                string token = "[authentication token here]";
                string boundry = "----------------------------7b053ae48e94";
                var encoding = new System.Text.ASCIIEncoding();
                var fileInfo = new FileInfo(fileName);
                var ms = new MemoryStream();
                long totalBytes = 0;
                string txt = string.Format("--{0}{2}Content-Disposition: form-data; name=\"file\"; filename=\"{1}\"{2}Content-Type: application/octet-stream{2}{2}", boundry, fileInfo.Name, Environment.NewLine);
                int bytesRead = 0;
                var buffer = new byte[32768];
                bytesRead = encoding.GetBytes(txt, 0, txt.Length, buffer, 0);
                totalBytes += bytesRead;
                ms.Write(buffer, 0, bytesRead);
                // read/write file contents to the stream
                var fs = new FileStream(fileName, FileMode.Open);
                while ((bytesRead = fs.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, bytesRead);
                    totalBytes += bytesRead;
                }
                txt = Environment.NewLine + "--" + boundry + "--" + Environment.NewLine;
                bytesRead = encoding.GetBytes(txt, 0, txt.Length, buffer, 0);
                totalBytes += bytesRead;
                ms.Write(buffer, 0, bytesRead);
                ms.Position = 0;
                var request = (HttpWebRequest)WebRequest.Create(string.Format("https://build.phonegap.com/api/v1/apps/{0}?auth_token={1}", appId, token));
                request.ContentLength = totalBytes;
                request.Method = "PUT";
                request.ContentType = "multipart/form-data; boundary=" + boundry;
                var requestStream = request.GetRequestStream();
                while ((bytesRead = ms.Read(buffer, 0, buffer.Length)) > 0)
                    requestStream.Write(buffer, 0, bytesRead);
                requestStream.Close();
                Console.WriteLine(new StreamReader(request.GetResponse().GetResponseStream()).ReadToEnd());
                Console.ReadLine();
            }
        }
    }
