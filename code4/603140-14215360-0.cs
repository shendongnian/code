    var doc = XDocument.Load("http://www.bloomberg.com/feed/podcast/on-the-economy.xml");
        
    XNamespace itunes = "http://www.itunes.com/dtds/podcast-1.0.dtd";
    
    var query = doc.Root.Elements("channel")
                    .Elements("item")
                    .Select(p => new BloomergFeeds
                    {
                        Title = p.Element("title").Value,
                        Link = p.Element("link").Value,
                        Guid = p.Element("guid").Value,
                        PublishDate = p.Element("pubDate").Value,
                        Itunes = new Itunes
                        {
                            Author = p.Elements(itunes + "author").First().Value,
                            Subtitle = p.Elements(itunes + "subtitle").First().Value,
                            Summary = p.Elements(itunes + "summary").First().Value,
                            Duration = p.Elements(itunes + "duration").First().Value,
                            Keywords = p.Elements(itunes + "keywords").First().Value,
                        }
                    }).ToList();
     public class BloomergFeeds
     {
         public string Title { get; set; }
         public string Link { get; set; }
         public string Guid { get; set; }
         public string PublishDate { get; set; }
         public Itunes Itunes { get; set; }
      }
    
      public class Itunes
      {
         public string Author { get; set; }
         public string Subtitle { get; set; }
         public string Summary { get; set; }
         public string Duration { get; set; }
         public string Keywords { get; set; }
      }
