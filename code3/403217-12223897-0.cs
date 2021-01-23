    private static string GetOperaCookiePath()
    {
        string s = Environment.GetFolderPath(
            Environment.SpecialFolder.ApplicationData);
        s += @"\Opera\Opera\cookies4.dat";
    
        if (!File.Exists(s))
            return string.Empty;
    
        return s;
    }
    private static bool GetCookie_Opera(string strHost, string strField, ref string Value)
    {
        Value = "";
        bool fRtn = false;
        string strPath;
    
        // Check to see if Opera Installed
        strPath = GetOperaCookiePath();
        if (string.Empty == strPath) // Nope, perhaps another browser
            return false;
    
        try
        {
            OpraCookieJar cookieJar = new OpraCookieJar(strPath);
            List<O4Cookie> cookies = cookieJar.GetCookies(strHost);
    
            if (null != cookies)
            {
                foreach (O4Cookie cookie in cookies)
                {
                    if (cookie.Name.ToUpper().Equals(strField.ToUpper()))
                    {
                        Value = cookie.Value;
                        fRtn = true;
                        break;
                    }
                }
            }
         }
        catch (Exception)
        {
            Value = string.Empty;
            fRtn = false;
        }
        return fRtn;
    }
