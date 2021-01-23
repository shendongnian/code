    class Frob
    {
        public Frob (Uri uri)
	    {
	    }
        public Frob(string path, string query)
            : this(TidyUpUri(path, query))
        {
        }
        private static Uri TidyUpUri(string path, string query)
        {
            var uri = new Uri(string.Concat(path, query));
            // etc.
            return uri;
        }
    }
