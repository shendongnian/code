            var date = new DateTime(2013, 1, 12);
            List<DateTime> dates = new List<DateTime>() { new DateTime(2013, 1, 11), date, new DateTime(2013, 1, 13) };
            double[] values = new double[] { 0, 1, 2 };
            var filtered = dates.Where(x => x == date);
            foreach (var found in filtered)
            {
                Console.Write(values[dates.IndexOf(found)]);
            }
            Console.ReadLine();
