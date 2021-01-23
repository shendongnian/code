    class BasePage : Page
    {
       ...
       public string MySessionObject
       {
          get
          {
             if(Session["myKey"] == null)
                return string.Empty;
             return Session["myKey"].ToString();
          }
          set
          {
              Session["myKey"] = value;
          }
       }
       ...
    }
