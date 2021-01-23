    public static class MyStringExtenstionClass
    {
        
        public static string SpaceToUnderScore(this string source)
        {
            string result = null;
            char[] cArray = source.ToArray();
            foreach (char c in cArray)
            {
                if (char.IsWhiteSpace(c))
                {
                    result += "_";
                }
                else
                {
                    result += c;
                }
            }
            return result;
        }
    }
