        /// <summary>
        /// Given a URL in any format, return URL with specified query string param removed if it exists
        /// </summary>
        public static string StripQueryStringParam(string url, string paramToRemove)
        {
            return StripQueryStringParams(url, new List<string> {paramToRemove});
        }
        /// <summary>
        /// Given a URL in any format, return URL with specified query string params removed if it exists
        /// </summary>
        public static string StripQueryStringParams(string url, List<string> paramsToRemove)
        {
            if (paramsToRemove == null || !paramsToRemove.Any()) return url;
            var splitUrl = url.Split('?');
            if (splitUrl.Length == 1) return url;
            var urlFirstPart = splitUrl[0];
            var urlSecondPart = splitUrl[1];
            // Even though in most cases # isn't available to context,
            // we may be passing it in explicitly for helper urls
            var secondPartSplit = urlSecondPart.Split('#');
            var querystring = secondPartSplit[0];
            var hashUrlPart = string.Empty;
            if (secondPartSplit.Length > 1)
            {
                hashUrlPart = "#" + secondPartSplit[1];
            }
            var nvc = HttpUtility.ParseQueryString(querystring);
            if (!nvc.HasKeys()) return url;
            // Remove any matches
            foreach (var key in nvc.AllKeys)
            {
                if (paramsToRemove.Contains(key))
                {
                    nvc.Remove(key);
                }
            }
            if (!nvc.HasKeys()) return urlFirstPart;
            return urlFirstPart + 
                   "?" + string.Join("&", nvc.AllKeys.Select(c => c.ToString() + "=" + nvc[c.ToString()])) + 
                   hashUrlPart;
        }
