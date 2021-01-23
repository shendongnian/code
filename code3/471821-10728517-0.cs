    public class Contributor
    {
          public string Name { get; set; }
          public string RSSUrl { get; set; }
          public Contributor(string name, string rssURL)
          {
                  Name = name;
                  RSSUrl = rssURL;
          }
    }
