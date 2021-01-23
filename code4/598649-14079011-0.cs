    [DllImport("wininet.dll", CharSet = CharSet.Auto, SetLastError = true)]
    static extern bool InternetGetCookieEx(string pchURL, string pchCookieName, StringBuilder pchCookieData, ref uint pcchCookieData, int dwFlags, IntPtr lpReserved);
    const int INTERNET_COOKIE_HTTPONLY = 0x00002000;
    private static string GetGlobalCookies(string uri)
    {
        uint datasize = 2048;
        StringBuilder cookieData = new StringBuilder((int)datasize);
        if (InternetGetCookieEx(uri, null, cookieData, ref datasize, INTERNET_COOKIE_HTTPONLY, IntPtr.Zero)
            && cookieData.Length > 0)
        {
            return cookieData.ToString();
        }
        else
        {
            return null;
        }
    }
    public void downloadsheet(string url, string path)
    {
        try
        {
            using (WebClient client = new WebClient())
            {
                string tmpCookieString = GetGlobalCookies(webBrowser1.Url.AbsoluteUri);
                client.Headers.Add(HttpRequestHeader.Cookie, tmpCookieString);
                
                client.Headers.Add("Accept", "text/html, application/xhtml+xml, */*");
                client.Headers.Add("User-Agent", "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.1; WOW64; Trident/4.0; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; Media Center PC 6.0; .NET4.0C; .NET4.0E; InfoPath.2)");
                client.Headers.Add("Accept-Language", "en-US");
                using (FileStream file = File.Create(path))
                {
                    byte[] bytes = client.DownloadData(url);
                    file.Write(bytes, 0, bytes.Length);
                }
            }
        }
        catch (Exception exp_DE)
        {
        }
    }
