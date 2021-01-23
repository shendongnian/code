    for(int i = 0; i < list.Count; i ++)
    {
      list1 = new List<string> { list[i] };
      listcombinations.Add(list1);
      for(int j = i + 1; j < list.Count; j ++)
      {
        list1 = new List<string> { list[i], list[j] };
        listcombinations.Add(list1);
        for(int k = j + 1; k < list.Count; k ++)
        {
          list1 = new List<string> { list[i], list[j], list[k] };
          listcombinations.Add(list1);
        }
      }
    }
