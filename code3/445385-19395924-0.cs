    private static void FindAllButtonControls(HtmlNodeCollection htmlNodeCollection, List<HtmlNode> controlNodes)
    {
        foreach (HtmlNode childNode in htmlNodeCollection)
        {
            if (childNode.Name.Equals("asp:button"))
            {
                controlNodes.Add(childNode);
            }
            else
            {
                FindAllButtonControls(childNode.ChildNodes, controlNodes);
            }
        }
    }
    
    public static List<HtmlNode> FindButtonControlsAtVirtualPath(String path)
    {
        HtmlAgilityPack.HtmlDocument aspx = new HtmlAgilityPack.HtmlDocument();
    
        aspx.OptionFixNestedTags = true;
        aspx.Load(HttpContext.Current.Server.MapPath(path));
    
        List<HtmlNode> controlNodes = new List<HtmlNode>();
        FindAllButtonControls(aspx.DocumentNode.ChildNodes, controlNodes);
    
        return controlNodes;
    }
