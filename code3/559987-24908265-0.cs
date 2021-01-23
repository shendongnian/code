    const int INTERNET_COOKIE_HTTPONLY = 0x00002000;
    
    [DllImport("wininet.dll", CharSet = CharSet.Unicode, SetLastError = true)]
    static extern bool InternetGetCookieEx(string pchURL, string pchCookieName, StringBuilder pchCookieData, ref System.UInt32 pcchCookieData, int dwFlags, IntPtr lpReserved);
    static string InternetGetCookieEx(string url)
    {
        uint sizeInBytes = 0;
        InternetGetCookieEx(url, null, null, ref sizeInBytes, INTERNET_COOKIE_HTTPONLY, IntPtr.Zero);
        uint bufferCapacityInChars = (uint)Encoding.Unicode.GetMaxCharCount((int)sizeInBytes);
        var cookieData = new StringBuilder((int)bufferCapacityInChars);
        InternetGetCookieEx(url, null, cookieData, ref bufferCapacityInChars, INTERNET_COOKIE_HTTPONLY, IntPtr.Zero);
        return cookieData.ToString();
    }
