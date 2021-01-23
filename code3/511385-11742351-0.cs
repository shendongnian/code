            string webUrl = "http://www.google.com";
            using (WebClient client = new WebClient())
            {
                client.Credentials = new NetworkCredential("UUU", "PPP");
                
                int counter = 0;
                
                using (StreamReader reader = new StreamReader(client.OpenRead(webUrl), Encoding.UTF8, true))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (line == "XXXXXX")
                        {
                            break;
                        }
                        counter++;
                    }
                }
            }
            Console.WriteLine("Try to Close Stream Reader...");
            Console.WriteLine("Stream Reader İSclosed...");
 
