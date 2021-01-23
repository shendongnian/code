        public static bool ContainsAny(this string databaseString, List<string> stringList)
        {
            if (databaseString == null)
            {
                return false;
            }
            foreach (string s in stringList)
            {
                if (databaseString.Contains(s))
                {
                    return true;
                }
            }
            return false;
        }
