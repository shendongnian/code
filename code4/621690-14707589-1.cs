    public static class HtmlExtensions
    {
        public static IHtmlString ActionLinkLocalized(
            this HtmlHelper html, 
            string translationText, 
            string actionName, 
            object routeValues
        )
        {
            var urlHelper = new UrlHelper(html.ViewContext.RequestContext);
            var anchor = new TagBuilder("a");
            anchor.Attributes["href"] = urlHelper.Action(actionName, routeValues);
            anchor.InnerHtml = TranslationHelper.GetTranslation(translationText);
            return new HtmlString(anchor.ToString());
        }
    }
