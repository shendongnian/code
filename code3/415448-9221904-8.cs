        public static string GetXPath_ByPosition(this XmlElement element)
        {
            string path = "/" + element.Name;
            XmlElement parentElement = element.ParentNode as XmlElement;
            if (parentElement != null)
            {
                // Gets the position within the parent element, based on previous siblings of the same name.
                // However, this position is irrelevant if the element is unique under its parent:
                XPathNavigator navigator = parentElement.CreateNavigator();
                int count = Convert.ToInt32(navigator.Evaluate("count(" + element.Name + ")"));
                if (count > 1)
                {
                    navigator = element.CreateNavigator();
                    path = path + "[" + navigator.Evaluate("position()") + "]";
                }
                // Climbing up to the parent elements:
                path = parentElement.GetXPath_UsingPreviousSiblings() + path;
            }
            return path;
        }
