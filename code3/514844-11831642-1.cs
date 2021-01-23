      XmlDocument doc = new XmlDocument();
        doc.LoadXml("link to yuor xml");
        XNamespace xmlns = "local2";
        public static void SetDefaultXmlNamespace(XElement xelem, XNamespace xmlns)
        {
          
            foreach(var e in xelem.Elements())
                e.SetDefaultXmlNamespace(xmlns);
        }
        
        doc.Root.SetDefaultXmlNamespace("local2")
