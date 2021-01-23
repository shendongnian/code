    public static class SessionHelper
        {
            public static void SetSessionKey(SessionKey sessionKey, object value)
            {
                HttpContext.Current.Session.Add(sessionKey.ToString(), value.ToString());
            }
    
            public static String GetSessionKey(SessionKey sessionKey)
            {
                return HttpContext.Current.Session[sessionKey.ToString()] as string;
            }
         }
    }
