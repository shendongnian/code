    public static class HtmlButtonExtension 
    {
      public static MvcHtmlString Button(this HtmlHelper helper, string text,
                                     IDictionary<string, object> htmlAttributes)
      {
          var builder = new TagBuilder("button");
          builder.InnerHtml = text;
          builder.MergeAttributes(htmlAttributes);
          return MvcHtmlString.Create(builder.ToString());
      }
    }
