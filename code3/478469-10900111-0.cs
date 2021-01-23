    ServiceWse serivce = new ServiceWse();
    CookieContainer cookieContainer = new CookieContainer();
    serivce.Timeout = 1000 * 60 * CommonFunctions.GetConfigValue<int>(Consts.Common.WebServiceTimeout, 20);
    serivce.Url = CommonFunctions.GetConfigValue(Consts.Urls.MyServiceSecuredURL, string.Empty);
    serivce.CookieContainer = cookieContainer;
    if (CommonFunctions.GetConfigValue(Consts.Security.UseSecuredServices, false))
        CommonFunctions.SetWSSecurity(_service.RequestSoapContext);
