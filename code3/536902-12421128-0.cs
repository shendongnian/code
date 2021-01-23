    public static class Extensions
    {
        public static bool HasNumbers(this string s)
        {
            foreach (char c in s)
            {
                if (char.IsDigit(c))
                {
                    return true;
                }
            }
    
            return false;
        }
    }
