    var tempList1 = input.Split(':').ToList();
    
    var tempList2 = tempList1.SelectMany((s, index) =>
     {
         if (index == 0 || index == tempList1.Count - 1)
             return new List<string>() { s };
    
         var subList = s.Split(',');
         return new List<string>
               { 
                    string.Concat(subList.Take(subList.Length - 1)),
                    subList.Last()
               };
     }).ToList();
    
    var result = Enumerable.Range(0, tempList2.Count / 2)
             .Select(i => string.Join(": ", tempList2[2 * i], tempList2[2 * i + 1]));
                          
