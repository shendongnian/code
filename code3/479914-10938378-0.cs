     public static class UriExtensions
        {
            private static readonly Regex QueryStringRegex = new Regex(@"[\?&](?<name>[^&=]+)=(?<value>[^&=]+)");
    
            public static IEnumerable<KeyValuePair<string, string>> ParseQueryString(this Uri uri)
            {
                if (uri == null)
                    throw new ArgumentException("uri");
    
                var matches = QueryStringRegex.Matches(uri.OriginalString);
                for (var i = 0; i < matches.Count; i++)
                {
                    var match = matches[i];
                    yield return new KeyValuePair<string, string>(match.Groups["name"].Value, match.Groups["value"].Value);
                }
            }
        }
