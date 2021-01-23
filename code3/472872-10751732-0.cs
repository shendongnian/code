     public static Regex REGEX_GETURLCOUNT =
        new Regex(@"<div[^>]+id=""aggregateCount""[^>]+>(\d*)</div>");
        public int GetPlusOnes(string url)
        {
            string fetchUrl =
                "https://plusone.google.com/u/0/_/+1/fastbutton?url=" +
                HttpUtility.UrlEncode(url) + "&count=true";
            string response = gp.Request(fetchUrl);
            Match match = REGEX_GETURLCOUNT.Match(response);
            if (match.Success)
            {
                return int.Parse(match.Groups[1].Value);
            }
            return 0;
        }
