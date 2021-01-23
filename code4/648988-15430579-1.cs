        foreach (placeObject)
            {
                XmlElement placeNode = xDoc.CreateElement("Placemark");
                docNode.AppendChild(placeNode);
                XmlElement nameNode = xDoc.CreateElement("Name");
                XmlText nameText = xDoc.CreateTextNode(PlaceObject.Name);
                placeNode.AppendChild(nameNode);
                nameNode.AppendChild(nameText);
                XmlElement descNode = xDoc.CreateElement("Description");
                XmlText descText = xDoc.CreateTextNode(PlaceObject.Name);
                placeNode.AppendChild(descNode);
                descNode.AppendChild(descText);
                XmlElement pointNode = xDoc.CreateElement("Point");
                placeNode.AppendChild(pointNode);
                XmlElement coordNode = xDoc.CreateElement("coordinates");
                XmlText coordText = xDoc.CreateTextNode(string.Format("{0},{1}", PlaceObject.Lng, PlaceObject.Lat));
                pointNode.AppendChild(coordNode);
                coordNode.AppendChild(coordText);
            }
            return xDoc;
