    public class CurrentUser     
    {          
     public static string UserName         
     {             
        get             
        {                 
          if (HttpContext.Current.Session["UserName"] != null)                     
             return (string)HttpContext.Current.Session["UserName"];
          else                     
             return null;             
        }              
        set             
        {                
          if (HttpContext.Current.Session["UserName"] == null)
             HttpContext.Current.Session.Add("UserName", value);
          else
             HttpContext.Current.Session["UserName"] = value;            
        }         
      }     
    }
