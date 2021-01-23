       string s = "Central Time (US & Canada)";
        s = s.Replace(" ", "+");
        s = System.Web.HttpUtility.UrlEncode(s);
        s = s.Replace("(", "%28");
        s = s.Replace(")", "%29");
        s = s.Replace("%26", "%2526");
        s = s.Replace("%", "%25");
        if (s.ToLower() == "Central%252BTime%252B%2528US%252B%252526%252BCanada%2529".ToLower())
        {
            System.Diagnostics.Debug.WriteLine("Success");
        }
