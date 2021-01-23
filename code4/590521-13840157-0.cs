        public static int Min(List<int> set)
        {
            Contract.Requires(set != null);
            Contract.Requires(set.Count>0);
            
            Contract.Ensures(Contract.ForAll(set, x => x >= Contract.Result<int>()));
            
            int min = set.Min();
            return min;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(Min(new List<int> { })); // should fail
            Console.WriteLine(Min(new List<int> { 3, 4, 5 }));
            Console.ReadKey();
        }
