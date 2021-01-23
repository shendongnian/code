        public static string GetXPath_SequentialIteration(this XmlElement element)
        {
            string path = "/" + element.Name;
            XmlElement parentElement = element.ParentNode as XmlElement;
            if (parentElement != null)
            {
                // Gets the position within the parent element.
                // However, this position is irrelevant if the element is unique under its parent:
                XmlNodeList siblings = parentElement.SelectNodes(element.Name);
                if (siblings != null && siblings.Count > 1) // There's more than 1 element with the same name
                {
                    int position = 1;
                    foreach (XmlElement sibling in siblings)
                    {
                        if (sibling == element)
                            break;
                        position++;
                    }
                    path = path + "[" + position + "]";
                }
                // Climbing up to the parent elements:
                path = parentElement.GetXPath_SequentialIteration() + path;
            }
            return path;
        }
