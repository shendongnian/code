    public class ChangeLanguageAttribute : ActionFilterAttribute
    {
      public override void OnActionExecuting(
         ActionExecutingContext filterContext)
      {
         string languageCode = "fr";
         CultureInfo info =
           CultureInfo.CreateSpecificCulture(languageCode.ToString());
         Thread.CurrentThread.CurrentCulture = info;
         Thread.CurrentThread.CurrentUICulture = info;
      }
    }
