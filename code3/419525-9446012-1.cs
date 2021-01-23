    class Program
    {
        static void Main(string[] args)
        {
            Feed feed = new Feed();
            feed.Title = "Exmple Feed";
            feed.Updated = DateTime.Now;
            feed.Link = new Link { Href = "http://example.org/" };
            feed.Entries.Add(
            new Entry
            {
                Title = "Atom-Powered Robots Run Amok",
                Link = new Link { Href = "http://example.org/2003/12/13/atom03" },
                Updated = DateTime.Now,
                Summary = "Some text."
            });
            XmlSerializer serializer = new XmlSerializer(typeof(Feed), "http://www.w3.org/2005/Atom");
            using (StreamWriter sw = new StreamWriter("c:\\testatom.xml"))
            {
                serializer.Serialize(sw, feed);
            }
            using (StreamReader sr = new StreamReader("c:\\testatom.xml"))
            {
                Feed readFeed = serializer.Deserialize(sr) as Feed;
            }
        }
    }
