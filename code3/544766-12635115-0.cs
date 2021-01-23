    public static class IntExtensions
    {
        public static int[] ToArray(this int i)
        {
            return i.ToString().Select(c => int.Parse(c.ToString())).ToArray();
        }
    }
