    List<List<string>> NewList = new List<List<string>>();
    foreach (var item in OriginalList.GroupBy(x => x))
    {
          NewList.Add(item.ToList());
    }
