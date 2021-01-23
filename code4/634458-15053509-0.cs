    public static class MyExtensions
    {
        public static string Shift(this string s, int count)
        {
            return s.Remove(0, count) + s.Substring(0, count);
        }
    }
