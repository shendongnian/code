            var list = new[]
            {
                new {Date = new DateTime(2013,07,12), value = 10220},
                new {Date = new DateTime(2013,07,12), value = 10220},
                new {Date = new DateTime(2013,07,12), value = 12220},
                new {Date = new DateTime(2013,07,12), value = 11240},
                new {Date = new DateTime(2013,07,12), value = 15220},
                new {Date = new DateTime(2013,07,13), value = 23220},
                new {Date = new DateTime(2013,07,13), value = 35620},
                new {Date = new DateTime(2013,07,14), value = 15620},
                new {Date = new DateTime(2013,07,14), value = 15620},
            };
            var res = from l in list group l by new { l.Date } into g select new { g.Key.Date, value = g.Distinct().Count() };
            foreach (var item in res)
            {
                Console.WriteLine(item.Date + " " + item.value);
            }
