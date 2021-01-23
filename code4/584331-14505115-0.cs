    static void Main ( string [] args )
            {
               XNamespace xmlns = XNamespace.Get("http://www.sitemaps.org/schemas/sitemap/0.9");
               XNamespace xsi = XNamespace.Get("http://www.w3.org/2001/XMLSchema-instance");
               XNamespace schemaLocation = XNamespace.Get("http://www.sitemaps.org/schemas/sitemap/0.9 http://www.sitemaps.org/schemas/sitemap/0.9/sitemap.xsd");
    
               XElement urlset = new XElement(xmlns+"urlset",
                         new XAttribute(XNamespace.Xmlns + "xsi", xsi),
                         new XAttribute(xsi + "schemaLocation", schemaLocation));       
                
                urlset.Add(new XElement(xmlns+"url")); // NB> We are qualifying the node
                var s = urlset.ToString ( );
                Console.ReadKey ( );
            }
