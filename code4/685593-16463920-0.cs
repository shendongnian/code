    private string userID;
    public string ID {
        get {
            if (userID == null) {
                if (System.Web.HttpContext.Current.Request.Headers.AllKeys.Contains("UID")) {
                    userID = System.Web.HttpContext.Current.Request.Headers["UID"].ToString();
                } else {
                    userID = "0000";
                }
            }
            return userID;
        }
    }
