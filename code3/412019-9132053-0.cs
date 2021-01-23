    using System;
    using System.Net;
    using System.Xml;
    
    namespace TechCrunch
    {
      class Program
      {
        public static void Main(string[] args)
        {
          Console.WriteLine("Hello World!");
    
          try
          {
            HttpWebRequest request = HttpWebRequest.CreateHttp(
              "http://feeds.feedburner.com/TechCrunch");
            WebResponse response = request.GetResponse();
    
            XmlDocument feedXml = new XmlDocument();
            feedXml.Load(response.GetResponseStream());
    
            XmlNamespaceManager mgr = new XmlNamespaceManager(feedXml.NameTable);
            mgr.AddNamespace("content", "http://purl.org/rss/1.0/modules/content/");
            mgr.AddNamespace("wfw", "http://wellformedweb.org/CommentAPI/");
            mgr.AddNamespace("dc", "http://purl.org/dc/elements/1.1/");
            mgr.AddNamespace("atom", "http://www.w3.org/2005/Atom");
            mgr.AddNamespace("sy", "http://purl.org/rss/1.0/modules/syndication/");
            mgr.AddNamespace("slash", "http://purl.org/rss/1.0/modules/slash/");
            mgr.AddNamespace("georss", "http://www.georss.org/georss");
            mgr.AddNamespace("geo", "http://www.w3.org/2003/01/geo/wgs84_pos#");
            mgr.AddNamespace("media", "http://search.yahoo.com/mrss/");
            mgr.AddNamespace("feedburner", "http://rssnamespace.org/feedburner/ext/1.0");
    
            XmlNodeList itemList = feedXml.SelectNodes("//channel/item");
            Console.WriteLine("Found " + itemList.Count + " items.");
    
            foreach(XmlNode item in itemList)
            {
              foreach(XmlNode child in item.ChildNodes)
              {
                Console.WriteLine("There is a child named " + child.Name);
              }
            }
          }
          catch(Exception ex)
          {
            Console.WriteLine(ex.ToString());
          }
    
          Console.Write("Press any key to continue . . . ");
          Console.ReadKey(true);
        }
      }
    }
