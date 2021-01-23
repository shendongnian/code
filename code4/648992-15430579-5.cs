        char[] delimiterLine = { '|' };
        char[] delimiterPoint = { ',' };
        string[] places = line.Split(delimiterLine);
        for (int i = 0; i < places.length; i++)
            {
                string[] placeMark = places[i].split(delimiterPoint);
                XmlElement placeNode = xDoc.CreateElement("Placemark");
                docNode.AppendChild(placeNode);
                XmlElement nameNode = xDoc.CreateElement("Name");
                XmlText nameText = xDoc.CreateTextNode(placeMark[0]);
                placeNode.AppendChild(nameNode);
                nameNode.AppendChild(nameText);
                XmlElement descNode = xDoc.CreateElement("Description");
                XmlText descText = xDoc.CreateTextNode(placeMark[1]);
                placeNode.AppendChild(descNode);
                descNode.AppendChild(descText);
                XmlElement pointNode = xDoc.CreateElement("Point");
                placeNode.AppendChild(pointNode);
                XmlElement coordNode = xDoc.CreateElement("coordinates");
                XmlText coordText = xDoc.CreateTextNode(string.Format("{0},{1}", placeMark[2], placeMark[3]));
                pointNode.AppendChild(coordNode);
                coordNode.AppendChild(coordText);
            }
            return xDoc;
