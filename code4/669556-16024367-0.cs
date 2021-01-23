    public string TextNotIncluded { 
        get { 
            return System.Web.HttpUtility.HtmlEncode("which is <u>not</u> included in the Quote"); 
        }
    }
