    public static partial class HtmlHelperExtensions
    {
        public static MvcHtmlString Image(this HtmlHelper helper,
                                    string url,
                                    object htmlAttributes)
        {
            return Image(helper, url, null, htmlAttributes);
        }
        public static MvcHtmlString Image(this HtmlHelper helper,
                                        string url,
                                        string altText,
                                        object htmlAttributes)
        {
            TagBuilder builder = new TagBuilder("image");
            var path = url.Split('?');
            string pathExtra = "";
            // NB - you'd make your test for the existence of the image here
            // and create it if it didn't exist, then return the path to 
            // the newly created image - for better or for worse!! :)
            if (path.Length > 1)
            {
                pathExtra = "?" + path[1];
            }
            builder.Attributes.Add("src", VirtualPathUtility.ToAbsolute(path[0]) + pathExtra);
            builder.Attributes.Add("alt", altText);
            builder.MergeAttributes(new RouteValueDictionary(htmlAttributes));
            return MvcHtmlString.Create(builder.ToString(TagRenderMode.SelfClosing));
        }
    }   
