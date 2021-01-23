    XElement elementNode = element.Descendants()
                                    .FirstOrDefault(id => id.Attribute("id").Value == "4");
            elementNode.RemoveNodes();
            while (elementNode.Parent != null)
            {
                XElement lastNode = new XElement(elementNode);
                elementNode = elementNode.Parent;
                elementNode.RemoveNodes();
                elementNode.DescendantsAndSelf().Last().AddFirst(lastNode);
            }
