    {
        string inStr = "ó";
        string auxStr = System.Net.WebUtility.HtmlEncode(inStr);
        // auxStr == &#243;
        string outStr = System.Net.WebUtility.HtmlDecode(auxStr);
        // outStr == &#243;
        string outStr2 = System.Net.WebUtility.HtmlDecode("&oacute;");
        // outStr2 == ó
    }
