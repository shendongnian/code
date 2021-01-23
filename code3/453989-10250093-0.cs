            List<string> db = new List<string>() {
                "RB OL",
                "OT LB",
                "OT OL"
            };
            List<string> tests = new List<string> {
                "RB", "LB", "OT"
            };
            IEnumerable<string> result = db.Where(d => d.Contains("RB"));
            for (int i = 1; i < tests.Count(); i++) {
                string val = tests[i];
                result = result.Union(db.Where(d => d.Contains(val)));
            }
            result.ToList().ForEach(r => Console.WriteLine(r));
            Console.ReadLine();
