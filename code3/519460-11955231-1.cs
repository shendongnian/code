       public static string GetXPath_UsingPreviousSiblings(this XmlElement element)
        {
            string path = "/" + element.Name;
    
            XmlElement parentElement = element.ParentNode as XmlElement;
            if (parentElement != null)
            {
                // Gets the position within the parent element, based on previous siblings of the same name.
                // However, this position is irrelevant if the element is unique under its parent:
                XPathNavigator navigator = parentElement.CreateNavigator();
                int count = Convert.ToInt32(navigator.Evaluate("count(" + element.Name + ")"));
                if (count > 1) // There's more than 1 element with the same name
                {
                    int position = 1;
                    XmlElement previousSibling = element.PreviousSibling as XmlElement;
                    while (previousSibling != null)
                    {
                        if (previousSibling.Name == element.Name)
                            position++;
    
                        previousSibling = previousSibling.PreviousSibling as XmlElement;
                    }
    
                    path = path + "[" + position + "]";
                }
    
                // Climbing up to the parent elements:
                path = parentElement.GetXPath_UsingPreviousSiblings() + path;
            }
    
            return path;
        }
