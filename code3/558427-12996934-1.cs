       new List<string>
                        {
                            "http://www.stackoverflow.com",
                            "http://www.google.com"
                        }
                        .AsParallel().ForAll(x =>
                                                 {
                                                     var client = new WebClient();
                                                     client.DownloadStringAsync(new Uri(x));
                                                     client.DownloadStringCompleted +=
                                                         (o, e) =>
                                                             {
                                                                 var result = e.Result; // html will be here
                                                                 Console.WriteLine("Completed");
                                                             };
                                                 });
