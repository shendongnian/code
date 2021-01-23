    public class UserDC
    {
        public static string UserId
        {
            get
            {
                 if(Session["UserId"] != null)
                     return Session["UserId"].ToString();
                 else 
                     return "";
            }
        }
    }
