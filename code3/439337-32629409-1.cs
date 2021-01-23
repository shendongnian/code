        private static bool ContainsKey(System.Collections.Specialized.NameValueCollection nvc, string key)
        {
            foreach (string str in nvc.AllKeys)
            {
                if (System.StringComparer.InvariantCultureIgnoreCase.Equals(str, key))
                    return true;
            }
            return false;
        }
