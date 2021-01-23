    /// <summary>
    /// Although it's invalid, in the wild we sometimes see a Set-Cookie header with the form "Name=Value; expires=Sun, 23-Dec-2012 12:25:37 GMT".
    /// Multiple cookies can be set with one header, comma separated, so CookieContainer.SetCookies() can't parse this due to the comma in the date.
    /// Fortunately, the DayOfWeek provides no useful information, and the date can be parsed without it, so this removes the day and comma.
    /// </summary>
    public static void SetCookiesWithExpires(this CookieContainer cookies, Uri uri, String cookieHeader) {
        // Note: The Regex may be created more than once in different threads. No problem; all but the last will be garbage collected.
        Regex expiresEqualsDay = _expiresEqualsDay ?? (_expiresEqualsDay = new Regex(EXPIRES_EQUALS_DAY_PATTERN, RegexOptions.IgnoreCase | RegexOptions.Compiled));
        cookies.SetCookies(uri, expiresEqualsDay.Replace(cookieHeader, EXPIRES_EQUALS));
    }
    private static Regex _expiresEqualsDay;     // Lazy-initialized.
    private const String EXPIRES_EQUALS_DAY_PATTERN = "; *expires=[A-Za-z]+, *";
    private const String EXPIRES_EQUALS = "; Expires=";
