            String myUrl = "www.facebook.com";
            System.Text.RegularExpressions.Regex url = new System.Text.RegularExpressions.Regex(@"/^(https?:\/\/)?([\da-z\.-]+)\.([a-z\.]{2,6})([\/\w \.-]*)*\/?$/", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.MatchCollection matches = url.Matches(myUrl);
            foreach (System.Text.RegularExpressions.Match match in matches)
            {
                string matchedUrl = match.Groups["url"].Value;
                Uri uri = new UriBuilder(matchedUrl).Uri;
                myUrl = myUrl.Replace(matchedUrl, uri.AbsoluteUri);
            }
