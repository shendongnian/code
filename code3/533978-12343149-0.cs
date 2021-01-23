    // List<long> list; int index; long value
    if (index > list.Count()) 
    {
      list.AddRange(Enumerable<long>.Repeat(0, index - list.Count());
    }
    list[index] = value;
