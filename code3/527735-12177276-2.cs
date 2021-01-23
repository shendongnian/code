    public static class NTreeXmlHelper
    {
        public static XElement TreeAsXml<T>(this NTree<T> node)
        {
            XElement element = new XElement("Node",
                                      new XAttribute("value", node.data));
            foreach (var child in node.children)
            {
                element.Add(TreeAsXml(child));
            }
            return element;
        }
    }
