     public class LogUtility
        {
       
            public static string DealingException(Exception x)
            {
                Exception logException = x;
                if (x != null)
                {
                    logException = x;
                }
    
                string strErrorMsg = Environment.NewLine + "URL ERROR:\t" + System.Web.HttpContext.Current.Request.Path;
    
                strErrorMsg += Environment.NewLine + "URL:\t" + System.Web.HttpContext.Current.Request.RawUrl;
    
                strErrorMsg += Environment.NewLine + "Message:\t" + (logException.Message != null ? logException.Message : "Not Found");
    
                
                strErrorMsg += Environment.NewLine + "Source:\t" + (logException.Source != null ? logException.Source : "Not Found");
    
                
                strErrorMsg += Environment.NewLine + "Stack Trace:\t" + (logException.StackTrace != null ? logException.StackTrace : "Not found");
                
                strErrorMsg += Environment.NewLine + "Destination URL:\t" + (logException.TargetSite.ToString() != null ? logException.TargetSite.ToString() : "Not found");
    
                strErrorMsg += Environment.NewLine;
                strErrorMsg += Environment.NewLine;
                return strErrorMsg;
            }
        }
