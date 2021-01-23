    public static class XPathNavigatorExtensions
    {
        public static string GetChildNodeValue(this XPathNavigator navigator, string nodePath)
        {
            XPathNavigator nav = navigator.SelectSingleNode(nodePath);
            return nav == null ? string.Empty : nav.Value;
        }
    }
