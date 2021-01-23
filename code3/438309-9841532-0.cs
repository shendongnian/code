    public class DAL
    {
        public static int CreatebyID
        {
            get
            {
                return (int)HttpContext.Current.Session["CreatebyID"];
            }
            set
            {
                HttpContext.Current.Session["CreatebyID"] = value;
            }
        }
        public static int EditbyID
        {
            get
            {
                return (int)HttpContext.Current.Session["EditbyID"];
            }
            set
            {
                HttpContext.Current.Session["EditbyID"] = value;
            }
        }
    }
