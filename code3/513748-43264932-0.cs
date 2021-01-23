     using (WebClient client = new WebClient())
            {
               client.Credentials = CredentialCache.DefaultCredentials; 
               byte[] bytes = File.ReadAllBytes(filePath);
               client.UploadDataAsync(new Uri(url), bytes);
            }
