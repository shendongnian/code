    public static T FetchValue<T>(
       string name, 
       T default_value = null) where T : class //!
    {
      var page = HttpContext.Current.Handler as Page;
    
      string str = page.Request.QueryString[name];
    
      if (str == null)
      {
        if (default_value == null)
        {
          throw new HttpRequestValidationException("A " + name + " must be specified.");
        }
        else
        {
          return default_value;
        }
      }
    
      return (T)Convert.ChangeType(str, typeof(T));
    }
