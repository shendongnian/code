     public static string DownloadXmlString(string address)
            {
                string text;
                using (var client = new WebClient())
                {
                    client.Headers["Accept"] = "application/xml";
                    text = client.DownloadString(address);
                }
                return text;
            }
    
            private static void Main(string[] args)
            {    
                Console.WriteLine(DownloadXmlString(@"http://www.ploscompbiol.org/article/info%3Adoi%2F10.1371%2Fjournal.pcbi.1002244"));    
            }
