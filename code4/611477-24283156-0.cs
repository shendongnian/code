                        using (var webClient = new System.Net.WebClient())
                        {
                            webClient.Proxy = proxy;
                          
                            webClient.DownloadString("url");
                            
                        }
