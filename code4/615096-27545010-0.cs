      public static class UriExtensions{
        /// <summary>
        ///     Adds query string value to an existing url, both absolute and relative URI's are supported.
        /// </summary>
        /// <example>
        /// <code>
        ///     // returns "www.domain.com/test?param1=val1&amp;param2=val2&amp;param3=val3"
        ///     new Uri("www.domain.com/test?param1=val1").ExtendQuery(new Dictionary&lt;string, string&gt; { { "param2", "val2" }, { "param3", "val3" } }); 
        /// 
        ///     // returns "/test?param1=val1&amp;param2=val2&amp;param3=val3"
        ///     new Uri("/test?param1=val1").ExtendQuery(new Dictionary&lt;string, string&gt; { { "param2", "val2" }, { "param3", "val3" } }); 
        /// </code>
        /// </example>
        /// <param name="uri"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static Uri ExtendQuery(this Uri uri, IDictionary<string, string> values) {
          var baseUrl = uri.ToString();
          var queryString = string.Empty;
          if (baseUrl.Contains("?")) {
            var urlSplit = baseUrl.Split('?');
            baseUrl = urlSplit[0];
            queryString = urlSplit.Length > 1 ? urlSplit[1] : string.Empty;
          }
    
          NameValueCollection queryCollection = HttpUtility.ParseQueryString(queryString);
          foreach (var kvp in values ?? new Dictionary<string, string>()) {
            queryCollection[kvp.Key] = kvp.Value;
          }
          var uriKind = uri.IsAbsoluteUri ? UriKind.Absolute : UriKind.Relative;
          return queryCollection.Count == 0 
            ? new Uri(baseUrl, uriKind) 
            : new Uri(string.Format("{0}?{1}", baseUrl, queryCollection), uriKind);
        }
    
        /// <summary>
        ///     Adds query string value to an existing url, both absolute and relative URI's are supported.
        /// </summary>
        /// <example>
        /// <code>
        ///     // returns "www.domain.com/test?param1=val1&amp;param2=val2&amp;param3=val3"
        ///     new Uri("www.domain.com/test?param1=val1").ExtendQuery(new { param2 = "val2", param3 = "val3" }); 
        /// 
        ///     // returns "/test?param1=val1&amp;param2=val2&amp;param3=val3"
        ///     new Uri("/test?param1=val1").ExtendQuery(new { param2 = "val2", param3 = "val3" }); 
        /// </code>
        /// </example>
        /// <param name="uri"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static Uri ExtendQuery(this Uri uri, object values) {
          return ExtendQuery(uri, values.GetType().GetProperties().ToDictionary
          (
              propInfo => propInfo.Name,
              propInfo => { var value = propInfo.GetValue(values, null); return value != null ? value.ToString() : null; }
          ));
        }
      }
