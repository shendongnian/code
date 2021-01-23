    using System.Text.RegularExpressions;
    
    public static List<string> ParseUrls(string input) {
        List<string> urls = new List<string>();
        const string pattern = "http://"; //here you may use a better expression to include ftp and so on
        string[] m = Regex.Split(input, pattern);
        for (int i = 0; i < m.Length; i++)
            if (i % 2 == 0){
                Match urlMatch = Regex.Match(m[i],"^(?<url>[a-zA-Z0-9/?=&.]+)", RegexOptions.Singleline);
                if(urlMatch.Success)
                    urls.Add(string.Format("http://{0}", urlMatch.Groups["url"].Value)); //modify the prefix according to the chosen pattern                            
            }
        return urls;
    }
