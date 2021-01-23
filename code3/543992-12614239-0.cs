    private Dictionary<string, string> backUrls
    {
        get
        {
            var dic = Session["backdic"] as Dictionary<string, string>;
            if ( dic == null )
            {
                dic = new Dictionary<string, string>();
            }
            return dic;
        }
    }
