    public static class MyExtensions {
        public static int[] IndexesOf<T>(this T[] Values, T find) {
            return Values.Select((i,index) => new { index = index, value = i})
                         .Where(x => x.value == find)
                         .Select(x => x.index)
                         .ToArray();
        }
    }
