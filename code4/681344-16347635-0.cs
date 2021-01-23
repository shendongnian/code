            XmlNamespaceManager manager = new XmlNamespaceManager(xmlDoc.NameTable);
            manager.AddNamespace("ns", "vx.sx");
            XmlNode badge = xmlDoc.SelectSingleNode("//ns:Badge", manager);
       
            if (badge == null)
            {
              // no badge element
            }
            else
            {
                // badge element present
            }
