    string s1 = "abc ";
    string s2 = "abc%20";
    if (System.Web.HttpUtility.UrlDecode(s1).Equals(System.Web.HttpUtility.UrlDecode(s2)))
    {
        //equals...
    }
