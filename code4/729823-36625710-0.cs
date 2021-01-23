    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            var recs = p.ReadVisitorsByMonthly();
            Console.WriteLine();
            foreach (var r in recs)
            {
                Console.WriteLine(r);
            }
            Console.ReadLine();
        }
        public List<string> ReadVisitorsByMonthly()
        {
            Dictionary<int, int> retL = new Dictionary<int, int>();
            List<DateTime> liste = new List<DateTime>();
            List<string> ret = new List<string>();
            liste.Add(new DateTime(2016, 4, 1));
            liste.Add(new DateTime(2016, 4, 4));
            liste.Add(new DateTime(2016, 4, 5));
            liste.Add(new DateTime(2016, 4, 2));
            liste.Add(new DateTime(2016, 4, 3));
            liste.Add(new DateTime(2015, 11, 6));
            liste.Add(new DateTime(2015, 12, 7));
            liste.Add(new DateTime(2015, 12, 8));
            liste.Add(new DateTime(2015, 11, 4));
            liste.Add(new DateTime(2015, 12, 4));
            liste.Add(new DateTime(2016, 5, 1));
            liste.Add(new DateTime(2016, 5, 6));
            liste.Add(new DateTime(2016, 5, 2));
            liste.Add(new DateTime(2016, 5, 3));
            liste.Add(new DateTime(2016, 2, 8));
            liste.Add(new DateTime(2016, 2, 6));
            liste.Add(new DateTime(2016, 2, 2));
            liste.Add(new DateTime(2016, 2, 1));
            liste.Add(new DateTime(2016, 1, 3));
            liste.Add(new DateTime(2016, 3, 5));
            liste.Add(new DateTime(2016, 3, 4));
            liste.Add(new DateTime(2016, 3, 7));
            liste.Add(new DateTime(2016, 3, 3));
            liste.Add(new DateTime(2016, 3, 5));
            var list = liste.GroupBy(j => j.Month).ToList();
            foreach (var g in list)
            {
                Console.WriteLine(g.Key.ToString("D2") + " - " + g.Count());
                retL.Add(g.Key, g.Count());
            }
            var thisMonth = DateTime.Now.Month;
            var finalList = retL.OrderBy(j => (thisMonth - (j.Key > thisMonth ? j.Key - 12 : j.Key))).ToList();
            foreach (var kvp in finalList)
            {
                string strMonthName = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(kvp.Key);
                ret.Add(kvp.Key.ToString().PadRight(3) + strMonthName.PadRight(8) + kvp.Value);
            }
            return ret;
        }
    }
