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
