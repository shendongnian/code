        public sealed class FixUrlsInCssFilter : ISingleContentFilter
    {
        /// <inheritdoc cref="IContentFilter.CanApplyTo" />
        public bool CanApplyTo(ResourceType resourceType)
        {
            return resourceType == ResourceType.CSS;
        }
        /// <inheritdoc cref="ISingleContentFilter.TransformContent" />
        public string TransformContent(ResourceSet resourceSet, Resource resource, string content)
        {
            string baseUrl = AppSettings.GetImageBaseUrl();
            return Regex.Replace(content, @"url\((?<url>.*?)\)", match => FixUrl(resource, match, baseUrl),
                RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.ExplicitCapture);
        }
        private static string FixUrl(Resource resource, Match match, string baseUrl)
        {
            try
            {
                const string template = "url(\"{0}\")";
                var url = match.Groups["url"].Value.Trim('\"', '\'');
                while (url.StartsWith("../", StringComparison.Ordinal))
                {
                    url = url.Substring(3); // skip one '../'
                }
                if (!baseUrl.EndsWith("/"))
                    baseUrl += "/";
                if (baseUrl.StartsWith("http"))
                {
                    return string.Format(CultureInfo.InvariantCulture, template, baseUrl + url);
                }
                else
                    return string.Format(CultureInfo.InvariantCulture, template, (baseUrl + url).ResolveUrl());
            }
            catch (Exception ex)
            {
                // Be lenient here, only log.  After all, this is just an image in the CSS file
                // and it should't be the reason to stop loading that CSS file.
                EventManager.RaiseExceptionEvent("Cannot fix url " + match.Value, ex);
                return match.Value;
            }
        }
    }
    #region Required to override FixUrlsInCssFilter for Combres
    public static class CombresExtensionMethods
    {
        /// <summary>
        ///   Returns the relative HTTP path from a partial path starting out with a ~ character or the original URL if it's an absolute or relative URL that doesn't start with ~.
        /// </summary>
        public static string ResolveUrl(this string originalUrl)
        {
            if (string.IsNullOrEmpty(originalUrl) || IsAbsoluteUrl(originalUrl) || !originalUrl.StartsWith("~", StringComparison.Ordinal))
                return originalUrl;
            /* 
             * Fix up path for ~ root app dir directory
             * VirtualPathUtility blows up if there is a 
             * query string, so we have to account for this.
             */
            var queryStringStartIndex = originalUrl.IndexOf('?');
            string result;
            if (queryStringStartIndex != -1)
            {
                var baseUrl = originalUrl.Substring(0, queryStringStartIndex);
                var queryString = originalUrl.Substring(queryStringStartIndex);
                result = string.Concat(VirtualPathUtility.ToAbsolute(baseUrl), queryString);
            }
            else
            {
                result = VirtualPathUtility.ToAbsolute(originalUrl);
            }
            return result.StartsWith("/", StringComparison.Ordinal) ? result : "/" + result;
        }
        private static bool IsAbsoluteUrl(string url)
        {
            int indexOfSlashes = url.IndexOf("://", StringComparison.Ordinal);
            int indexOfQuestionMarks = url.IndexOf("?", StringComparison.Ordinal);
            /*
             * This has :// but still NOT an absolute path:
             * ~/path/to/page.aspx?returnurl=http://www.my.page
             */
            return indexOfSlashes > -1 && (indexOfQuestionMarks < 0 || indexOfQuestionMarks > indexOfSlashes);
        }
    }
    #endregion
