        public static int RegexCacheSize()
        {
            var fi = typeof(Regex).GetField("livecode", BindingFlags.Static 
                                                      | BindingFlags.NonPublic);
            var coll = (ICollection)(fi.GetValue(null));
            return coll.Count;
        }
