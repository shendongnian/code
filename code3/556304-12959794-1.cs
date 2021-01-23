    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                using (var client = new HttpClient())
                {
                    // Initialize HTTP client
                    client.BaseAddress  = new Uri("http://localhost:26242/api/", UriKind.Absolute);
                    client.Timeout      = TimeSpan.FromSeconds(10);
    
                    // Build session data to send
                    var values          = new List<KeyValuePair<string, string>>();
    
                    values.Add(new KeyValuePair<string, string>("Item1", "Value1"));
                    values.Add(new KeyValuePair<string, string>("Item2", "Value2"));
                    values.Add(new KeyValuePair<string, string>("Item3", "Value3"));
    
                    // Send session data via POST using form-url-encoded content
                    using (var content = new FormUrlEncodedContent(values))
                    {
                        using (var response = client.PostAsync("session", content).Result)
                        {
                            Console.WriteLine(response.StatusCode);
                        }
                    }
                }
            }
        }
    }
