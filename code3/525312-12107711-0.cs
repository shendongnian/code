    XElement element = XElement.Parse(@"
    <rss>
    <channel>
    <item title='something' pubDate='22/11/2012'/>
    <item title='something2' pubDate='24/03/2012'/>
    <item title='something3' pubDate='10/02/2010'/>
    <item title='something4' pubDate='22/01/2011'/>
    </channel>
    </rss>");
    
    var elements = element.Element("channel")
    				.Elements("item")
    				.OrderBy<XElement, DateTime>(e => DateTime.ParseExact(e.Attribute("pubDate").Value, "dd/MM/yyyy", null))
    				.Select(e => new XElement("item",
    					new XElement("title", e.Attribute("title").Value),
    					new XElement("pubDate", e.Attribute("pubDate").Value))); // Do transform here.
    			
    			element.Element("channel").ReplaceAll(elements);
    			
    			Console.Write(element.ToString());
