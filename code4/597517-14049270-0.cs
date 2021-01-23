    class Program
    {
        static void Main(string[] args)
        {
            int[] index = { 0, 2, 1 };
            var query = from p in index
                        where p != 0
                        orderby p descending
                        select p;
            Console.WriteLine(query.FirstOrDefault());
            Console.ReadKey();
        }
    }
