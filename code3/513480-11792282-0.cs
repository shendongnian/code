    using System;
    using System.IO;
    using System.Net;
    using System.Text;
    
    namespace ImgurExample
    {
        class Program
        {
            static void Main(string[] args)
            {
                PostToImgur(@"C:\Users\ashwin\Desktop\image.jpg", IMGUR_ANONYMOUS_API_KEY);
            }
    
            public static void PostToImgur(string imagFilePath, string apiKey)
            {
                byte[] imageData;
    
                FileStream fileStream = File.OpenRead(imagFilePath);
                imageData = new byte[fileStream.Length];
                fileStream.Read(imageData, 0, imageData.Length);
                fileStream.Close();
    
                const int MAX_URI_LENGTH = 32766;
                string base64img = System.Convert.ToBase64String(imageData);
                StringBuilder sb = new StringBuilder();
    
                for(int i = 0; i < base64img.Length; i += MAX_URI_LENGTH) {
                    sb.Append(Uri.EscapeDataString(base64img.Substring(i, Math.Min(MAX_URI_LENGTH, base64img.Length - i))));
                }
    
                string uploadRequestString = "image=" + sb.ToString() + "&key=" + imgurApiKey;
    
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create("http://api.imgur.com/2/upload");
                webRequest.Method = "POST";
                webRequest.ContentType = "application/x-www-form-urlencoded";
                webRequest.ServicePoint.Expect100Continue = false;
    
                StreamWriter streamWriter = new StreamWriter(webRequest.GetRequestStream());
                streamWriter.Write(uploadRequestString);
                streamWriter.Close();
    
                WebResponse response = webRequest.GetResponse();
                Stream responseStream = response.GetResponseStream();
                StreamReader responseReader = new StreamReader(responseStream);
    
                string responseString = responseReader.ReadToEnd();
            }
        }
    }
