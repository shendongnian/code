    static void Main(string[] args) {
        string text = 
      @"break Start1 = 15/02/12 12.30PM
        break End1= 15/02/12 01.30PM
        break Start2 = 15/02/12 11.00AM
        break End2= 15/02/12 12.00PM
        break Start3 = 15/02/12 12.00PM
        break End3= 15/02/12 01.00PM";
        string[] splitted = text.Split(new string[] {"\n", "\r"}, StringSplitOptions.RemoveEmptyEntries);
        IList<DateTime> starts = new List<DateTime>();
        IList<DateTime> ends = new List<DateTime>();
        for (int i = 0; i < splitted.Length; i++) {
            string line = splitted[i].Trim();
            string date = line.Split('=')[1].Trim();
            DateTime d = DateTime.ParseExact(date, "dd/MM/yy hh.mmtt", null);
            if (line.StartsWith("break Start")) {
                starts.Add(d);
            }
            else {
                ends.Add(d);
            }
        }
        starts = starts.OrderBy(x => x).ToList();
        ends = ends.OrderBy(x => x).ToList();
        for (int i = 0; i < starts.Count; i++) {
            Console.WriteLine("break Start{0} = {1}", i + 1, starts[i].ToString("dd/MM/yy hh.mmtt"));
            Console.WriteLine("break End{0} = {1}", i + 1, ends[i].ToString("dd/MM/yy hh.mmtt"));
        }
    }
