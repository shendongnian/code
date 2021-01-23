        static void init_log()
        {
            GlobalContext.Properties["addr"] = System.Web.HttpContext.Current.Request.UserHostAddress;
            GlobalContext.Properties["browser"] = System.Web.HttpContext.Current.Request.Browser.Browser + " : " + System.Web.HttpContext.Current.Request.Browser.Version;
            GlobalContext.Properties["url"] = System.Web.HttpContext.Current.Request.Url.AbsoluteUri;
            log4net.Config.XmlConfigurator.Configure();
        }
