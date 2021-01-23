    public static class MyHelpers
    {
        private static Dictionary<string, object> SourceMetadata = new Dictionary<string, object> { { "HtmlHelper", typeof(MenuHelper).FullName } };
        public static MvcSiteMapNode GetNodeByKey(this MvcSiteMapHtmlHelper helper, string nodeKey)
        {
            SiteMapNode node = helper.Provider.FindSiteMapNodeFromKey(nodeKey);
            var mvcNode = node as MvcSiteMapNode;
            return mvcNode;
        }
    }
