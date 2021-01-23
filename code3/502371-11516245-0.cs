    g =>
                 {
                     var items = g.Distinct();
                     var result = new Dictionary<String, int>();
                     foreach (var item in items)
                         result[item] = g.Count(gitem => gitem == item);
                     return result;
                 }
