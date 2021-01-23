    public static IHtmlString MenuLink(this HtmlHelper htmlHelper, string text, string url)
        {
            var link = new TagBuilder("a");
            link.Attributes.Add("href", url);
            string currentUrl = HttpContext.Current.Request.RawUrl;
            if (string.Equals(url, currentUrl, StringComparison.OrdinalIgnoreCase))
            {
                link.AddCssClass("current");
            }
            link.InnerHtml = text;
            return new HtmlString(link.ToString());
        }
