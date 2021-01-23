     public static class Extensions
     {
        /// <summary>
        /// Turns a relative URL into a fully qualified URL.
        /// (ie http://domain.com/path?query) 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="relativeUrl"></param>
        /// <returns></returns>
        public static string GetFullUrl(this HttpRequest request, string relativeUrl) {
            return String.Format("{0}://{1}{2}",
                            request.Url.Scheme,
                            request.Url.Authority,
                            VirtualPathUtility.ToAbsolute(relativeUrl));
        }
     }
