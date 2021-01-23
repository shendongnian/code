    [TestMethod]
    public void FindValuesInStrings() {
      var strings = new[] {
         "a = 23, b = 432, f = 321, gfs = 11, d = 42, k = 4242, t = 4314",   //A
         "a = 12, b = 123, f = 456, gfs = 11, d = 42, k = 4242, t = 4314",   //B
         "a = 11, b = 456, f = 789, gfs = 413, d = 42, k = 4242, t = 4314",  //C
         "a = 23, b = 789, f = 12,  gfs = 13, d = 42, k = 4242, t = 4314",   //D
      };
       var dict = new Dictionary<string, IEnumerable<string>>();
       foreach (var str in strings) {
          dict.Add(str, str.Split(',').Select(s => s.Trim()));
       }
       // finds the two entries where a = 23 (A & D)
       var criteria = new[] { "a = 23" };
       var found = dict.Where(entry => 
           entry.Value.Intersect(criteria).Count() == criteria.Count()).Select(entry => entry.Key);
       Assert.AreEqual(2, found.Count());
       // finds the single entry where a = 23 and gfs = 11 (A)
       criteria = new[] { "a = 23", "gfs = 11" };
       found = dict.Where(entry => 
            entry.Value.Intersect(criteria).Count() == criteria.Count()).Select(entry => entry.Key);
       Assert.AreEqual(1, found.Count());
            
    }
