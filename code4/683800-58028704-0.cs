            X509Certificate clientKey1 = null;
            clientKey1 = new X509Certificate(AppSetting["certificatePath"],  
            AppSetting["pswd"]);
            string url = "Https://EndPointAddress";
            FileStream fs = File.OpenRead(FilePath);
            var streamContent = new StreamContent(fs);
            var FileContent = new ByteArrayContent(streamContent.ReadAsByteArrayAsync().Result);            
            FileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("ContentType");
            var handler = new WebRequestHandler();       
               
                
                handler.ClientCertificateOptions = ClientCertificateOption.Manual;
                handler.ClientCertificates.Add(clientKey1);
                handler.ServerCertificateValidationCallback = (httpRequestMessage, cert, cetChain, policyErrors) =>
                {
                    return true;
                };            
            
            using (var client = new HttpClient(handler))
            {
                // post it
                HttpResponseMessage httpResponseMessage = client.PostAsync(url, FileContent).Result;
                if (!httpResponseMessage.IsSuccessStatusCode)
                {
                    string ss = httpResponseMessage.StatusCode.ToString();
                }
            }   
