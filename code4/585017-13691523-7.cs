    public class HttpContextSessionParametreProvider
    {
      private string _name;
      private string _notSet;
    
      public HttpContextSessionParameterProvider(string name)
      {
        _name = name;
        _notSet = string.Format("{0} not set", _name);
      }
    
      public override string ToString()
      {
        HttpContext context = HttpContext.Current;  
        if (context != null && context.Session != null)
        {
          object item = context.Session[_name];
          if (item != null)
          {
            return item.ToString();
          }
        }
        return _notSet;
      }
    }
