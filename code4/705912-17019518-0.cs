    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    class Program {
        static void Main(string[] args) {
            string[] fileContents = new string[] { 
                    "2013-05-02 07:45:15",
                    "2013-05-02 09:25:01",
                    "2013-05-02 18:15:15",
                    "2013-05-04 08:45:15",
                    "2013-05-04 17:45:35"
                };
            List<DateTime> dates = fileContents.ToList().ConvertAll(s => DateTime.ParseExact(s, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture));
            foreach (var datesInSameDay in dates.GroupBy(d => d.Day)) {
                var datesList = datesInSameDay.ToList();
                datesList.Sort();
                Console.WriteLine(datesList.First());
                Console.WriteLine(datesList.Last());
            }
        }
    }
