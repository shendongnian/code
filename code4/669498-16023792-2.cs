    internal static List<string> BuildPaths(XmlDocument doc)
    {
        List<string> paths = new List<string>();
        BuildPaths(doc.DocumentElement, paths);
        return paths;
    }
    private static void BuildPaths(XmlNode node, List<string> paths, string prefix = "")
    {
        if (node.Name == "element")
        {
            // end case - elements named "element"
            paths.Add(prefix + "/" + node.Attributes["id"].Value);
        }
        else
        {                    // iterate through child nodes that are either not named element or that 
            // have an attribute named "id" (i.e. skip elements named "element" that 
            // lack an id attribute)
            foreach (XmlNode child in node.SelectNodes("*[not(self::element) or @id]"))
            {
                BuildPaths(child, paths, prefix + "/" + node.Name);
            }
        }
    }
