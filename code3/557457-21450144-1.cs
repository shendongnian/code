        using System.Net;
        using System.Text.RegularExpressions;
        static readonly Regex HttpQueryDelimiterRegex = new Regex(@"\?", RegexOptions.Compiled);
        static readonly Regex HttpQueryParameterDelimiterRegex = new Regex(@"&", RegexOptions.Compiled);
        static readonly Regex HttpQueryParameterRegex = new Regex(@"^(?<ParameterName>\S+)=(?<ParameterValue>\S*)$", RegexOptions.Compiled);
        static string GetPath(string pathAndQuery)
        {
            var components = HttpQueryDelimiterRegex.Split(pathAndQuery, 2);
            return components[0];
        }
        static Dictionary<string, string> GetQueryParameters(string pathAndQuery)
        {
            var parameters = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            var components = HttpQueryDelimiterRegex.Split(pathAndQuery, 2);
            if (components.Length > 1)
            {
                var queryParameters = HttpQueryParameterDelimiterRegex.Split(components[1]);
                foreach(var queryParameter in queryParameters)
                {
                    var match = HttpQueryParameterRegex.Match(queryParameter);
                    if (!match.Success) continue;
                    var parameterName = WebUtility.HtmlDecode(match.Groups["ParameterName"].Value) ?? string.Empty;
                    var parameterValue = WebUtility.HtmlDecode(match.Groups["ParameterValue"].Value) ?? string.Empty;
                    parameters[parameterName] = parameterValue;
                }
            }
            return parameters;
        }
