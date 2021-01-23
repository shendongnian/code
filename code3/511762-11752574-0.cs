    public static string GetResponseFromRequest(string url)
    {
        var req = System.Net.WebRequest.Create(url);
        using (var res = req.GetResponse())
        using (var sr = new StreamReader(res.GetResponseStream()))
            return sr.ReadToEnd();
    }
