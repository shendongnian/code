    public static class EvenFasterSumExtensions
    {
        public static int Sum(this int[] source)
        {
            int num = 0;
            for(int i = 0; i < source.Length; i++)
                num += source[i];
            return num;
        }
        public static int Sum(this List<int> source)
        {
            int num = 0;
            for(int i = 0; i < source.Count; i++)
                num += source[i];
            return num;
        }
    }
