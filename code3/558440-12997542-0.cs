    List<int> list = new List<int>() {1,2,3,1,1,1,1,2,2,4 }; //your TO's
    var newlist = list.InterlaceBy(x => x).ToList(); //1,2,3,4,1,2,1,2,1,1
    public static partial class MyExtensions
    {
        public static IEnumerable<T> InterlaceBy<T, S>(this IEnumerable<T> input, Func<T, S> selector)
        {
            return input
                  .GroupBy(selector)
                  .SelectMany(g => g.Select((x, i) => new { key = i, value = x }))
                  .OrderBy(x => x.key)
                  .Select(x => x.value);
        } 
    }
