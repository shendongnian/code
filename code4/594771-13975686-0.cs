            XmlNode specificNode = document.SelectSingleNode("/Response/a/b/c/d");
            if (specificNode != null)
            {
                foreach (XmlNode child in specificNode.ChildNodes)
                {
                    Console.WriteLine(child.InnerText);
                }
            }
