    var lists = new [] { list1, list2, list3 };
    var combined = new List<string>(lists.Sum(l => l.Count));    
    for (var i = 0; i < lists.Max(l => l.Count); i++)
    {
       foreach (var list in lists)
       { 
          if (i < list.Count)
              combined.Add (list[i])
       }
    }
