                string text;
                using (WebClient client = new WebClient())
                {
                    client.Headers["Accept"] = "application/xml";
                    text = client.DownloadString(@"http://api.discogs.com/release/" + line);
                }
                  
                  var elements = XElement.Parse(text);
                  var artists= elements.Descendants("artist")
                       .Select(e =>e.Element("role").Value 
                               + " " 
                               + e.Element("name").Value )
                       .ToList();
                  artists.ForEach(Console.WriteLine);
