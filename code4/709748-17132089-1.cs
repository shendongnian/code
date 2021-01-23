    public class UrlLogAppender : AppenderSkeleton
        {
    
            public string APIkey { get; set; }
            public string CustomerName { get; set; }
    
            protected override void Append(LoggingEvent loggingEvent)
            {
                try
                {
                    Base.LogToDataBase.WebService1 LogtoWebserver = new Base.LogToDataBase.WebService1();
    
        loggingEvent.Properties["addr"] = System.Web.HttpContext.Current.Request.UserHostAddress;
        loggingEvent.Properties["browser"] = System.Web.HttpContext.Current.Request.Browser.Browser + " : " + System.Web.HttpContext.Current.Request.Browser.Version;
        loggingEvent.Properties["url"] = System.Web.HttpContext.Current.Request.Url.AbsoluteUri;
    }
    }
    }
