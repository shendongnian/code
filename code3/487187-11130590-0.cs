    var list = new List<int>();
    list.Add(0); // 0
    list.Add(1); // 0, 1
    list.Add(2); // 0, 1, 2
    var item = 5;
    var count = 3;
    list.AddRange(Enumerable.Repeat(item, count)); // 0, 1, 2, 5, 5, 5
