            int[] groupA = { 1, 2, 3 };
            int[] groupB = { 4, 5 };
            var result = data
                .GroupBy(a => groupA.Contains(a.Group) ? "A" : 
                              groupB.Contains(a.Group) ? "B" : 
                              "N/a")
                .Select(a => new
                {
                    KEY = a.Key,
                    VALUE = a.Count()
                });
