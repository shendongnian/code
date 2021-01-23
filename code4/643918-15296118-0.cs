        static void Main(string[] args)
        {
            var months =
                Enumerable.Range(1, DateTime.Now.Month-1).Select(
                    p => new DateTime(DateTime.Now.Year, p, 1));
            foreach(var month in months)
                Console.WriteLine(month.ToString("MMM yyyy"));
            Console.ReadLine();
        }
