    var numbers = Enumerable.Range(0, 1000)
                            .Where(n => n % 3 == 0 || n % 5 == 0);
    foreach(var n in numbers)
    {
        Console.WriteLine(n);
    }
    var sum = numbers.Sum();
    Console.WriteLine(sum);
    Console.ReadLine();
