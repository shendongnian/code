    public class BreadCrumbOnlyVisibilityProvider : ISiteMapNodeVisibilityProvider
    {
        public bool IsVisible(SiteMapNode node, HttpContext context, IDictionary<string, object> sourceMetadata)
        {
            if (sourceMetadata["HtmlHelper"] == null || (string)sourceMetadata["HtmlHelper"] == "MvcSiteMapProvider.Web.Html.SiteMapPathHelper")
            {
                return true;
            }
            return false;
        }
    }
