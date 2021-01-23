    List<string> listOfStrings = {"A01", "B01", "A02", "B12", "C15", "A12"}.ToList();
    var res = listOfStrings.Select(p => p.Substring(0, 1)).Distinct().ToList().Select(p => 
    new {
           Key = p,
           Values = listOfStrings.Where(c => c.Substring(0, 1) == p)
    }).ToList();
    foreach (object el_loopVariable in res) {
         el = el_loopVariable;
         foreach (object x_loopVariable in el.Values) {
             x = x_loopVariable;
             Console.WriteLine("Key: " + el.Key + " ; Value: " + x);
         }
    }
    Console.Read();
