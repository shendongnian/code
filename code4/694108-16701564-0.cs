    public static string Something<T>(this System.Web.Mvc.HtmlHelper<T> helper, int value)
    {
         string viewName = Path.GetFileName(WebPageContext.Current.Page.VirtualPath);
         string someValueFromViewName = viewName.DoSomething();
         return someValueFromViewName;
    }
