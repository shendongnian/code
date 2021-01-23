        /// <summary>
        /// Sets/changes an url's query string parameter.
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="url">URL to process</param>
        /// <param name="key">Query string parameter key to set/change</param>
        /// <param name="value">Query string parameter value</param>
        /// <returns>Resulting URL</returns>
        public static string SetParameter(this UrlHelper helper, string url, string key, string value) {
            return helper.SetParameters(url, new Dictionary<string, object> {
                {key, value}
            });
        }
