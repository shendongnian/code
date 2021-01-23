    var orig = new Person {Id = 1, Name = "Anna"};
    var delta = new Person {Id = 1, Age = 25, City = "New York"};
    var merged = Merger.Merge(orig, delta);
    Console.WriteLine(merged.Id);
    Console.WriteLine(merged.Age);
    Console.WriteLine(merged.Name);
    Console.WriteLine(merged.City);
