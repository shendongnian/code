    XmlReader reader = XmlReader.Create(\\File Path);
    
            XElement doc = XElement.Load(reader);
    
            int counter = 0;
            foreach (XElement user in doc.Descendants("USER"))
            {
                try
                {
                    string node = user.Parent.Attribute("NAME").Value; //Working - Returning 'GlobalZoneEU'
                }
                catch (Exception)
                {
    
                }
            }
