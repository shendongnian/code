    public static string OutputHtmlHelperVersion(this HtmlHelper helper)
    {
      return helper.GetType().Assembly.GetName().Version.ToString();
    }
    
