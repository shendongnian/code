    class Program
    {
        static void Main(string[] args)
        {
            string xml = @"<?xml version='1.0' encoding='utf-8'?>
    <sitegroups>
    <sitegroup name = 'healthcare'>
            <site name='A' url='a.aspx'/>
            <site name='B' url='b.aspx'/>
    </sitegroup>
    <sitegroup name = 'diet'>
            <site name='C' url='c.aspx'/>
        <site name='D' url='d.aspx'/>
    </sitegroup>
    </sitegroups>";
    
            var doc  = XDocument.Parse(xml);
            XElement siteGroup = doc.Element("sitegroups").Elements().First(e => e.Attribute("name").Value == "healthcare");
            var newSite = new XElement("site", new XAttribute("name", "C"),
                                               new XAttribute("url", "http://www.google.com"));
            siteGroup.Add(newSite);
            Console.WriteLine(doc.ToString());
        }
    }
