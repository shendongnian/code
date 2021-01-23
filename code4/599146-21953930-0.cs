            private async Task PerformGet()
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync(myUrlGet);
                if (response.IsSuccessStatusCode)
                {
                    // if the response content is a byte array
                    byte[] contentBytes = await response.Content.ReadAsByteArrayAsync();
    
                    // if the response content is a stream
                    Stream contentStream = await response.Content.ReadAsStreamAsync();
    
                    // if the response content is a string (JSON or XML)
                    string json = await response.Content.ReadAsStringAsync();
    
                    // your stuff..
                }
            }
  
