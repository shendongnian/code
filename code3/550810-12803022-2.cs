    var list = new List<int> { 1, 2, 3, 4, 5 };
    
    var query = list.Where(num => num < 5);
    Console.WriteLine(query.Count());
    
    list.RemoveAll(num => num < 4);
    Console.WriteLine(query.Count()
