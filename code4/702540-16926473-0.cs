    public static string GetHTMLDocument(string url)
            {
                var result = "";
                using (var wc = new WebClient())
                {
                    result = wc.DownloadString(url);
                }
                return result;
            }
