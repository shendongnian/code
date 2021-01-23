                string text;
                using (WebClient client = new WebClient())
                {
                    client.Headers["Accept"] = "application/xml";
                    text = client.DownloadString(@"http://api.discogs.com/release/" + line);
                }
                  
                var doc = new XmlDocument();
                doc.LoadXml(text);
    
    
                Console.WriteLine(doc.InnerText);
