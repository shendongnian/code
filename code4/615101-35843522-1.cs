    public static class UriExtensions
    {
        /// <summary>
        /// Adds or Updates the specified parameter to the Query String.
        /// </summary>
        /// <param name="url"></param>
        /// <param name="paramName">Name of the parameter to add.</param>
        /// <param name="paramValue">Value for the parameter to add.</param>
        /// <returns>Url with added parameter.</returns>
        public static Uri AddOrUpdateParameter(this Uri url, string paramName, string paramValue)
        {
            var uriBuilder = new UriBuilder(url);
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);
            
			if (query.AllKeys.Contains(paramName))
			{
                query[paramName] = paramValue;
			}
			else
			{
			    query.Add(paramName, paramValue);
			}
            uriBuilder.Query = query.ToString();
    
            return uriBuilder.Uri;
        }
    }
