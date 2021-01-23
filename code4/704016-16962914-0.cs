       private List<string> findDegreesLoop()
       {
            var list1 = new List<string>();
            var list2 = new List<string>();
            var list3 = new List<string>();
            foreach (var degree in list2)
            {
                var matches = list1.Where(q => q.Contains(degree)).ToList();
                if (matches.Any())
                {
                   list3.AddRange(matches);
                }
            }
    return list3;
     }
      private List<string> findDegreesLinq()
     {
            var list1 = new List<string>();
            var list2 = new List<string>();
            var list3 = new List<string>();
            foreach (var matches in list2.Select(degree => list1.Where(q =>     q.Contains(degree)).ToList()).Where(matches => matches.Any()))
            {
                list3.AddRange(matches);
            }
    return list3;
      }
