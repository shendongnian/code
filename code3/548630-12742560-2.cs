    public static class ListEx
    {
        public static Tuple<int, int> BinarySearchWithCount<T>(
            this IList<T> list, T key)
        {
            int min = 0;
            int max = list.Count - 1;
            int counter = 0;
    
            while (min <= max)
            {
                counter++;
                int mid = (min + max) / 2;
                int comparison = Comparer<T>.Default.Compare(list[mid], key);
                if (comparison == 0)
                {
                    return new Tuple<int, int>(mid, counter);
                }
                if (comparison < 0)
                {
                    min = mid + 1;
                }
                else
                {
                    max = mid - 1;
                }
            }
    
            return new Tuple<int, int>(~min, counter);
        }
    }
    
    //Which returns a tuple with the item and a number of comparisons. 
    //Here is how you can use it:
    
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new List<int>();
            numbers.AddRange(Enumerable.Range(0, 100000));
    
            var answer = numbers.BinarySearchWithCount(2);
            Console.WriteLine("item: " + answer.Item1);   // item: 2
            Console.WriteLine("count: " + answer.Item2);  // count: 15
    
        }
    }
