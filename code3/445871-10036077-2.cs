    // Puts half a million elements in memory, sorts, then outputs them.
    var numbers = Enumerable.Range(1, 1000000).Where(i => i % 2 == 0)
        .OrderByDescending(i => i);
    foreach(var number in numbers) Console.WriteLine(number);
    // Puts one element in memory at a time.
    var numbers = Enumerable.Range(1, 1000000).Where(i => i % 2 == 0);
    foreach(var number in numbers) Console.WriteLine(number);
