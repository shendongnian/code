    public static class UserInfo
    {
        public static ClsUser showName()
        { 
            return (ClsUser)(HttpContext.Current.Session["USER"]);
        }
     }
