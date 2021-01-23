    static XmlDocument HTMLTEST()
            {
                string html = "<table frame=all><tgroup></tgroup></table>";
                TextReader reader = new StringReader(html);
    
                Sgml.SgmlReader sgmlReader = new Sgml.SgmlReader();
                sgmlReader.DocType = "HTML";
                sgmlReader.WhitespaceHandling = System.Xml.WhitespaceHandling.All;
                sgmlReader.InputStream = reader;
    
                XmlDocument doc = new XmlDocument();
                doc.PreserveWhitespace = true;  //false if you dont want whitespace
                doc.XmlResolver = null;
    
                doc.Load(sgmlReader);
    
                return doc;
            }
