    public static class RegexUtils
    {
        public static bool TryParse (string possibleRegex, out Regex regex)
        {
            regex = null;
            try
            {
                regex = new Regex(possibleRegex);
                return true;
            }
            catch (ArgumentException ae)
            {
               return false;
            }
        }
    }
