    public class UserDC
    {
        public static string UserId
        {
            get
            {
                 return Session["UserId"].ToString();
            }
        }
    }
