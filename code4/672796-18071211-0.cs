            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://someurl/");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            // Create NetworkCredential Object 
            NetworkCredential admin_auth = new NetworkCredential("username", "password");
            // Set your HTTP credentials in your request header
            httpWebRequest.Credentials = admin_auth;
            // callback for handling server certificates
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = "{\"name\":\"TEST_123\"}";
                streamWriter.Write(json); 
                streamWriter.Flush();
                streamWriter.Close();
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    Console.WriteLine(result);
                }
           }
