        /// <summary>
        /// Converts a relative path from the current directory to an absolute path 
        /// </summary>
        /// <param name="relativePath">Relative path from the current directory</param>
        public static string GetPath(string relativePath)
        {
            return System.IO.Path.Combine(Environment.CurrentDirectory, relativePath);
        }
        /// <summary>
        /// Converts a relative path from the current directory to an absolute Uri 
        /// </summary>
        /// <param name="relativePath">Relative path from the current directory</param>
        public static Uri GetPathUri(string relativePath)
        {
            return new Uri(GetPath(relativePath), UriKind.Absolute);
        }
