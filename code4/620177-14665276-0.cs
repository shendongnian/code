    //dummy data for testing purposes
    List<Tuple<string, string>> items = new List<Tuple<string, string>>();
    items.Add(new Tuple<string, string>("Dinner", "steak"));
    items.Add(new Tuple<string, string>("Dinner", "chicken"));
    items.Add(new Tuple<string, string>("Dinner", "chicken"));
    items.Add(new Tuple<string, string>("Desert", "chocolate"));
    var groups = (from t in items
                 group t by new {Course = t.Item1, Item = t.Item2}
                 into grp
                     select new
                     {
                         grp.Key.Course,
                         grp.Key.Item,
                         Quantity = grp.Count()
                     })
                 .OrderBy(g => g.Course);
    foreach (var g in groups)
              Console.WriteLine(string.Format("{0} {1} {2}", g.Course, g.Item, g.Quantity));
