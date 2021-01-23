    static class ListCopy
    {
        public static void ListCopyToEnd<TSource, TDest>(this IList<TSource> sourceList, IList<TDest> destList)
            where TSource : TDest // This lets us cast from TSource to TDest in the method.
        {
            foreach (TSource item in sourceList)
            {
                destList.Add(item);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<int> intList = new List<int> { 1, 2, 3 };
            List<object> objList = new List<object>(); ;
            ListCopy.ListCopyToEnd(intList, objList);
            // ListCopyToEnd is an extension method
            // This calls it for a second time on the same objList (copying values again).
            intList.ListCopyToEnd(objList);
            foreach (object obj in objList)
            {
                Console.WriteLine(obj);
            }
            Console.ReadLine();
        }
`
