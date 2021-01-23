    public static class RandomExt
    {
        public static T[] RandomizeOrder<T>(this T[] array)
        {
            var rand = new Random();
            return array.Select(x => new {x, r = rand.Next()})
                                           .OrderBy(x => x.r)
                                           .Select(x => x.x)
                                           .ToArray();
        }
    }
    int[] arrayInt = new[] {1, 2, 3, 4, 5, 6, 7}.RandomizeOrder();
