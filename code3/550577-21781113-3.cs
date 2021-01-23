    using System;
    using System.Globalization;
    using System.Web;
    using System.Web.Helpers;
    public class ContoscoAntiForgeryAdditionalDataProvider : IAntiForgeryAdditionalDataProvider {
      public string GetAdditionalData(HttpContextBase context) {
        if (context == null) {
          throw new ArgumentNullException("context");
        }
        var contoscoContext = new ContoscoHttpContext(context);
        int userID = contoscoContext.GetUserID().GetValueOrDefault();
        return Convert.ToString(userID, CultureInfo.InvariantCulture);
      }
      public bool ValidateAdditionalData(HttpContextBase context, string additionalData) {
        string data = GetAdditionalData(context);
        return string.Compare(data, additionalData, StringComparison.Ordinal) == 0;
      }
    }
  
    public class MvcApplication : HttpApplication {
      protected void Application_Start() {
        AntiForgeryConfig.AdditionalDataProvider = 
          new ContoscoAntiForgeryAdditionalDataProvider(); 
      }
    }
