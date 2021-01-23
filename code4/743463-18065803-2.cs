    public static class StringExtensionMethods
    {
        public static bool ContainsAny(this string self, params string[] toFind)
        {
            bool found = false;
            foreach(var criteria in toFind)
                {
                    if (self.Contains(criteria))
                    {
                        found = true;
                        break;
                    }
                };
            return found;
        }   // eo ContainsAny    
    }
