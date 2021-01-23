            XmlNode node = doc.SelectSingleNode("Magasin");
            XmlNodeList prop = node.SelectNodes("Items");
            foreach (XmlNode item in prop)
            {
                items Temp = new items();
                Temp.AssignInfo(item);
                lstitems.Add(Temp);
            }
