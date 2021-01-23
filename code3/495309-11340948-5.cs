        const string dateMask = "yyyy-MM-dd";
        public static void Dump(this IQueryable<DateRange> item, string msg)
        {
            Console.WriteLine(msg);
            foreach (var i in item)
            {
                Console.WriteLine(string.Format("{0} to {1}", i.fromDate.ToString(dateMask), i.toDate.ToString(dateMask)));
            }
        }
        public static void Dump(this IQueryable<DateTime> item, string msg)
        {
            Console.WriteLine(msg);
            foreach (var i in item)
            {
                Console.WriteLine(string.Format("{0}", i.ToString(dateMask)));
            }
        }
