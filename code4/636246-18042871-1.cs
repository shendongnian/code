    private static void fixCookies(HttpWebRequest request, HttpWebResponse response) 
    {
        for (int i = 0; i < response.Headers.Count; i++)
        {
            string name = response.Headers.GetKey(i);
            if (name != "Set-Cookie")
                continue;
            string value = response.Headers.Get(i);
            foreach (var singleCookie in value.Split(','))
            {
                Match match = Regex.Match(singleCookie, "(.+?)=(.+?);");
                if (match.Captures.Count == 0)
                    continue;
                response.Cookies.Add(
                    new Cookie(
                        match.Groups[1].ToString(), 
                        match.Groups[2].ToString(), 
                        "/", 
                        request.Host.Split(':')[0]));
            }
        }
    }
