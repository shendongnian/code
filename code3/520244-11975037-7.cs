    var tempList = input.Split(':')
                .SelectMany(s => {       
                      if (s.Contains(","))
                      {
                           var subList = s.Split(',');
                           return new List<string>
                           { 
                                string.Concat(subList.Take(subList.Length - 1)),
                                subList.Last()
                           };
                      }
                      return new List<string>() {s};
                  }).ToList();
    var result = Enumerable.Range(0, tempList.Count/2)
                   .Select(i => string.Join(": ", tempList[2*i], tempList[2*i + 1]));
                          
