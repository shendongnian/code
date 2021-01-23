        using System;
        using System.Collections;
        using System.Collections.Generic;
        using System.IO;
        using System.Linq;
        using System.Text;
        class Planner
        {
            public string firstName { get; set; }
            public DateTime dateTime { get; set; }
        }
        class exe
        {
            public static void Main(string[] args)
            {
                List<Planner> t = new List<Planner>();
                using (StreamReader sr = new StreamReader("Scheduler.txt"))
                {
                    string line = string.Empty;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] lines = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                        var planner = new Planner();
                        planner.firstName = lines[0];
                        var dateStr = String.Format("{0} {1}", lines[1], lines[2]);
                        var date = DateTime.ParseExact(dateStr, "dd/MM/yyyy hh:mmtt", System.Globalization.CultureInfo.InvariantCulture); //note the date format comes second. Also, in your examples days are first, months are second!
                        planner.dateTime = date;
                        t.Add(planner);
                    }
                }
                t = t.OrderBy(l => l.firstName).ThenBy(l => l.dateTime).ToList();
            }
        }
