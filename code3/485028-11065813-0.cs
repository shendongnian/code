    var sublist = new List<int> { 1, 2, 3 };
    var result = new List<List<int>> { sublist };
    //result[0] is now {1, 2, 3}
    sublist.Clear();
    //result[0] is now {}
    result.Add(sublist);
    //result[0], result[1], and sublist are the same instance
