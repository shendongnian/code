    public static class CustomConcat
        {
            public static IEnumerable<T> SingleConcat<T>(this IEnumerable<T> first, T lastElement)
            {
                foreach (T t in first)
                {
                    yield return t;
                }
    
                yield return lastElement;
            }
        }
    
        class Program
        {
    
    
            static void Main(string[] args)
            {
                List<int> mylist = new List<int> { 1 , 2 , 3};
    
                var newList = mylist.SingleConcat(4);
    
                foreach (var s in newList)
                {
                    Console.WriteLine(s);
                }
    
                Console.Read();
            }
        }
