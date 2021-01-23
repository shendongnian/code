    public void serializeXML(object portfolio, string xmlPath)
            {
                XmlSerializer serial = new XmlSerializer(portfolio.GetType());
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                ns.Add("", "");
                try
                {
                    using (FileStream fs = new FileStream(xmlPath, FileMode.Create, FileAccess.Write))
                    {
                        using (XmlTextWriter tw = new XmlTextWriter(fs, Encoding.UTF8))
                        {
                            tw.Formatting = Formatting.Indented;
                            serial.Serialize(tw, portfolio, ns);
                        }
    
                    }
                }
    }
