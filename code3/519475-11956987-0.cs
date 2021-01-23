    [TestMethod]
        public void TestCallUploadHandler()
        {
            const string FILE_PATH = "C:\\foo.txt";
            const string FILE_NAME = "foo.txt";
            string UPLOADER_URI =  string.Format("http://www.foobar.com/handler.ashx?filename={0}", FILE_NAME);
            using (var stream = File.OpenRead(FILE_PATH))
            {
                var httpRequest = WebRequest.Create(UPLOADER_URI) as HttpWebRequest;
                httpRequest.Method = "POST";
                NetworkCredential networkCredential = new NetworkCredential("username", "pwd"); 
                httpRequest.Credentials = networkCredential;
                stream.Seek(0, SeekOrigin.Begin);
                stream.CopyTo(httpRequest.GetRequestStream());
                byte[] authBytes = Encoding.UTF8.GetBytes("username:pwd".ToCharArray());
                httpRequest.Headers["Authorization"] = "Basic " + Convert.ToBase64String(authBytes);
                var httpResponse = httpRequest.GetResponse();
                StreamReader reader = new StreamReader(httpResponse.GetResponseStream());
                var responseString = reader.ReadToEnd();
                //Check the responsestring and see if all is ok
            }
        }
