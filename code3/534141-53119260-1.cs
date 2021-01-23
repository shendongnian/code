    public class PortalPage:System.Web.UI.Page
    {
        
        protected override void InitializeCulture()
        {
            string _language = (string)Session["Language"];
            if (_language == null)
            {
                _language = ConfigurationManager.AppSettings["DefaultLanguage"];
                Session["Language"] = _language;
            }
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture(_language);
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(_language);
            base.InitializeCulture();
        }
    }
