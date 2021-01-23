        static void Main(string[] args)
        {
            var dates = System.IO.File.ReadAllLines(@"C:\dates.txt").Select(o => DateTime.Parse(o));
            var res = new List<DateTime>();
            foreach (var item in (from o in dates group o by o.Date into g select g.Key))
            {
                var dummy = dates.Where(o => o.Date == item);
                res.Add(dummy.Max());
                res.Add(dummy.Min());
            }
        }
