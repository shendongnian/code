    // 500 items exist in both lists
    List<int> InputA = Enumerable.Range(0, 1000).ToList();
    List<int> InputB = Enumerable.Range(500, 1000).ToList();
    int Result1 = InputA.Where(a => InputB.Contains(a)).Count(); //13000 ticks
    int Result2 = InputA.Intersect(InputB).Count(); //5700 ticks
    
