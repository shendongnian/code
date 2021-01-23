    public static MvcHtmlString BuildImage(this HtmlHelper html, string src, Action<ImageUrlBuilder> configure, string alternateText = "", object htmlAttributes = null)
    {
      var imageUrl = html.CreateUrlHelper().ImageUrl(src, configure);
      return html.Image(imageUrl.ToString());
    }
    public static MvcHtmlString BuildImage(this HtmlHelper html, string src, ImageUrlBuilder builder, string alternateText = "", object htmlAttributes = null)
    {
      var imageUrl = html.CreateUrlHelper().ImageUrl(src, builder);
      return html.Image(imageUrl.ToString());
    }
