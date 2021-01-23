    static string LinksToHTML(string str)
        {
            Regex urlRx = new Regex(@"(?<url>(http:[/][/]|www.)([^\s])*)", RegexOptions.IgnoreCase);
            MatchCollection matches = urlRx.Matches(str);
            foreach (Match match in matches)
            {
                var url = match.Groups["url"].Value;
                str = str.Replace(url, string.Format("<a href=\"{0}\" target=\"blank\">{1}</a>", url, (url.Length > 40 ? url.Substring(0, 40) + "..." : url)));
                //str = str.Replace(url, string.Format("<a href=\"{0}\" target=\"blank\">{1}</a>", url, url));
            }
            return str;
        }
