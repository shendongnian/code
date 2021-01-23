    public static class MyExtensions // Name this class to whatever you want, but make sure it's static.
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
