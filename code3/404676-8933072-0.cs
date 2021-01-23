public static class HtmlHelpers
{ 
  public static string HyperLink(this HtmlHelper html, string text, string href) 
  {
    return string.Format(@"&lt;a href="{0}"&gt;{1}&lt;/a&gt;", href, text);
  }
} 
