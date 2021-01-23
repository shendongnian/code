    var list1 = new List<int> { 1, 2, 3, 4, 5 };
    var list2 = new List<int> { 0, 1, 2, 3, 5, 6 };
        
    foreach (var i in list2.Intersect(list1))
        Console.WriteLine(i); // Outputs 1, 2, 3, 5.
