    class Program
    {
        static void Main()
        {
            var json = 
            @"[
                {
                    ""status"": ""ok"",
                    ""result"": true
                },
                {
                    ""status"": ""ok"",
                    ""result"": [
                        {
                            ""name"": ""John Doe"",
                            ""UserIdentifier"": ""abc"",
                            ""MaxAccounts"": ""2""
                        }
                    ]
                }
            ]";
            var settings = new JsonSerializerSettings();
            settings.Converters.Add(new ResultConverter());
            Root[] root = JsonConvert.DeserializeObject<Root[]>(json, settings);
            // do something with the results here
        }
    }
