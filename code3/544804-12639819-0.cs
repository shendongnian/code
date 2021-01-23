    //Page extension
    static class PageExtensions
    {
        private static T FetchValue<T>(this Page page, string name, object defaultValue)
        {
            string str = page.Request.QueryString[name];
            if (string.IsNullOrEmpty(str))
            {
                if (defaultValue != null)
                    return (T)defaultValue;
                throw new HttpRequestValidationException("A " + name + " must be specified.");
            }
            //not the best way
            return (T)Convert.ChangeType(str, typeof(T));
        }
        public static T FetchValueFromCurrentPage<T>(string name, T defaultValue)
        { 
          var page = HttpContext.Current.Handler as Page;
          if(page == null)
            throw new InvalidOperationException("Current handler is not Page");
          return page.FetchValue<T>(name, defaultValue);
        }
        public static T FetchValueFromCurrentPage<T>(string name) where T : class
        {   
            return FetchValueFromCurrentPage(name, (T)null);
        }
    }
