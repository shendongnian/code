    public class WebConsProvider : IConsProvider
    {
      public string UserName
      {
        // DON'T USE .ToString()!  If it's null you get NullReferenceException!
        get{ return HttpContext.Current.Session["username"] as string; }
        set{ HttpContext.Current.Session["username"]=value; }
      }
    }
    public class DefaultConsProvider : IConsProvider 
    {
       public string UserName 
       {
         get; set;
       }
    }
