    public class CourierMessage
        {
            public string Id { get; set; }
            public string Key { get; set; }
            public string From { get; set; }
            public string Subject { get; set; }
            public string Body { get; set; }
            public DateTimeOffset Processed { get; set; }
            public DateTime Received { get; set; }
            public DateTime Created { get; set; }
            public DateTime Sent { get; set; }
            public HttpPostedFileBase File { get; set; }
        }  
  
     while (true)
                    {
                        Console.WriteLine("Hit any key to make request.");
                        Console.ReadKey();
        
        
                        using (var client = new HttpClient())
                        {
                            using (var multipartFormDataContent = new MultipartFormDataContent())
                            {
                                var values = new[]
                                {
                                    new KeyValuePair<string, string>("Id", Guid.NewGuid().ToString()),
                                    new KeyValuePair<string, string>("Key", "awesome"),
                                    new KeyValuePair<string, string>("From", "khalid@home.com")
                                     //other values
                                };
        
                                foreach (var keyValuePair in values)
                                {
                                    multipartFormDataContent.Add(new StringContent(keyValuePair.Value), 
                                        String.Format("\"{0}\"", keyValuePair.Key));
                                }
        
                                multipartFormDataContent.Add(new ByteArrayContent(File.ReadAllBytes("test.txt")), 
                                    '"' + "File" + '"', 
                                    '"' + "test.txt" + '"');
        
                                var requestUri = "http://localhost:5949";
                                var result = client.PostAsync(requestUri, multipartFormDataContent).Result;
                            }
                        }
                    }
