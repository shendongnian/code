                var webClient = new WebClient();
                webClient.Credentials = new NetworkCredential(email, password);                                     
                webClient.UploadDataCompleted += webClient_UploadDataCompleted;
                byte[] fileBytes = File.ReadAllBytes(zipFile);
                webClient.UploadDataAsync(new Uri(uri), "POST", fileBytes);
