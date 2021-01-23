            var topic = "<options>" + 
                   "<option value=\"123\" isSelectd=\"false\">X</option>" +
                   "<option value=\"456\" isSelectd=\"false\">XX</option>" + 
                   "</options>";
            int selectedValue = 456;
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(topic);
            foreach (XmlNode node in xmlDoc.ChildNodes[0].ChildNodes)
            {
                int value = Convert.ToInt32(node.Attributes[0].Value.ToString());
                if (value == selectedValue)
                    node.Attributes[1].Value = "ture";
            }
            topic = xmlDoc.InnerXml;
