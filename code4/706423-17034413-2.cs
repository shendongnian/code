         public static string DownloadString(string address)
                {
                    string text;
                    using (var client = new WebClient())
                    {
                        text = client.DownloadString(address);
                    }
                    return text;
                }
        
                private static void Main(string[] args)
                {    
                    var xml = DownloadString(@"http://www.ploscompbiol.org/article/fetchObjectAttachment.action?uri=info%3Adoi%2F10.1371%2Fjournal.pcbi.1002244&representation=XML");            
                    File.WriteAllText("blah.xml", xml);
                }
