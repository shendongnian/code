    var list = Enumerable.Empty<object>()
                 .Select(r => new {A = 0, B = 0}) // prototype of anonymous type
                 .ToList();
    list.Add(new { A = 4, B = 5 }); // adding actual values
    Console.Write(list[0].A);
