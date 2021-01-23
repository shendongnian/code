    namespace MyNameSpace
    {
        using System.Web;
        partial class SessionState
        {
                public static string ClientName
            {
                get
                {
                    object obj = HttpContext.Current.Session["clientName"];
                    if (obj != null)
                    {
                        return (string)obj;
                    }
                    return null;
                }
                set
                {
                    HttpContext.Current.Session["clientName"] = value;
                }
            }    
                public static string DealerID
            {
                get
                {
                    object obj = HttpContext.Current.Session["dealerID"];
                    if (obj != null)
                    {
                        return (string)obj;
                    }
                    return null;
                }
                set
                {
                    HttpContext.Current.Session["dealerID"] = value;
                }
            }    
            }
    }
