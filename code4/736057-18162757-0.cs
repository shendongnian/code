    public class MyNodeNotOnMenuVisibilityProvider
        : SiteMapNodeVisibilityProviderBase
    {
        public override bool IsVisible(ISiteMapNode node, IDictionary<string, object> sourceMetadata)
        {
            if (sourceMetadata.ContainsKey("HtmlHelper") && sourceMetadata["HtmlHelper"].ToString().Equals("MvcSiteMapProvider.Web.Html.MenuHelper"))
            {
                if (node.Key == "MyNode")
                {
                    return false;
                }
            }
            return true;
        }
    }
