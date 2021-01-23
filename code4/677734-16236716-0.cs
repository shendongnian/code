    public static class StringExtensions
    {
        public static string LimitOnWordBoundary(this string str, int count)
        {
            if (str.Length <= count - 3)
                return str;
            else
            {
                int lastspace = str.Substring(0, count - 3).LastIndexOf(' ');
                if (lastspace > 0 && lastspace > count - 20)
                {
                    // limits the backward search to a max of 20 chars
                    return str.Substring(0, lastspace) + "...";
                }
                else
                {
                    // No space in the last 20 chars, so get all the string minus 3
                    return str.Substring(0, count - 3) + "...";
                }
            }
        }
    }
