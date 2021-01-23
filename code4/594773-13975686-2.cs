            XmlNode specificNode = document.SelectSingleNode("/Response/ResourceSets/ResourceSet/Resources/Location/BoundingBox");
            if (specificNode != null)
            {
                foreach (XmlNode child in specificNode.ChildNodes)
                {
                    Console.WriteLine(child.InnerText);
                }
            }
