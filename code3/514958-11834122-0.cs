    public static bool OnTestingServer()
        {
            string host = HttpContext.Current.Request.Url.Host.ToLower();
            return (host == "localhost");
        }
