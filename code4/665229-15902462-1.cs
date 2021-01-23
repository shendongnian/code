    public ActionResult Login(string returnurl)
    {
       ....
       if(!string.IsNullOrWhiteSpace(returnurl)) {
           int lastIndex = returnurl.LastIndexOf("/") + 1;
           string strEventID = returnUrl.Substring(lastIndex);
           int EventID = Int32.Parse(strEventID);
       }
       ....
    }
