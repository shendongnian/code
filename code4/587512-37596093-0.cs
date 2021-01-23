     public static class ArrayExtensions
    {
        public static int MaxIndexOf<T>(this T[] input)
        {
            var max = input.Max();
            int index = Array.IndexOf(input, max);
            return index;
        }
    }
