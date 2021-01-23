    XElement element = XElement.Parse(XMLFILE);
            IEnumerable<XElement> list = element.Elements("sitemap");
            foreach (XElement e in list)
            {
                String LOC= e.Element("loc").Value;
                String LASTMOD = e.Element("lastmod").Value;
            }
