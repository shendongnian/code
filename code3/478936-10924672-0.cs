            byte[] response;
            using (var client = new WebClient())
            {
                try
                {
                    response = client.UploadValues(URL, "POST", postData);
                }
                catch (Exception ex)
                {
                    // Log error here                  
                }
            }
