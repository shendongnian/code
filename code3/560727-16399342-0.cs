    public static class CookieHelper
    {
        /// <summary>
        /// Checks whether a cookie exists.
        /// </summary>
        /// <param name="cookieCollection">A CookieCollection, such as Response.Cookies.</param>
        /// <param name="name">The cookie name to delete.</param>
        /// <returns>A bool indicating whether a cookie exists.</returns>
        public static bool Exists(this HttpCookieCollection cookieCollection, string name)
        {
            if (cookieCollection == null)
            {
                throw new ArgumentNullException("cookieCollection");
            }
            return cookieCollection[name] != null;
        }
    }
