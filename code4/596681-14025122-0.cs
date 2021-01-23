    List<List<Tuple<string, string>>> fixture = 
      ListMatches(new List<string> { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16" });
    bool switchOrder = false;
    foreach (round in fixture)
    {
      if (switchOrder)
      {
         foreach (var tuple in round)
         {
             string temp = tuple.Item1;
             tuple.Item1 = tuple.Item2;
             tuple.Item2 = temp;
         }
      }
      switchOrder = !switchOrder
    }
