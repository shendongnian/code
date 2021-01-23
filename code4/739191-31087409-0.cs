        public static IHtmlString Image(this HtmlHelper helper, byte[] image, string imgclass, 
                                         object htmlAttributes = null)
        {
            var builder = new TagBuilder("img");
            builder.MergeAttribute("class", imgclass);
            builder.MergeAttributes(new RouteValueDictionary(htmlAttributes));
            var imageString = image != null ? Convert.ToBase64String(image) : "";
            var img = string.Format("data:image/jpg;base64,{0}", imageString);
            builder.MergeAttribute("src", img);
            return MvcHtmlString.Create(builder.ToString(TagRenderMode.SelfClosing));
        }
