    public static string AppVersion(this HtmlHelper html)
    {
      var appInstance = html.ViewContext.HttpContext.ApplicationInstance;
      //given that you should then be able to do 
      var assemblyVersion = appInstance.GetType().Assembly.GetName().Version;
      //or possibly appInstance.GetType().BaseType.Assembly.GetName().Version
      //see note below.
      return assemblyVersion.ToString();
    }
