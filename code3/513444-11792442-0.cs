    var result = array.GetSixth(FirstTest).FirstOrDefault(SecondTest);
    
    internal static class MyExtensions
    {
          internal static IEnumerable<T> GetSixth<T>(this IEnumerable<T> source, Func<T, bool> predicate)
           {
                var counter=0;
                foreach (var item in source)
                {
                    if (counter==5) yield return item;
                    counter = predicate(item) ? counter + 1 : 0;
                }
            }
    }
