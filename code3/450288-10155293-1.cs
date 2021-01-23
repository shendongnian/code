    var x = new Int16_2d { a = 1, b = 2 };
    var set = new HashSet<Int16_2D> { x };
    var y = new Int16_2d { a = 1, b = 2 };
    Console.WriteLine(set.Contains(y));   // True
    x.a = 3;
    Console.WriteLine(set.Contains(y));   // False
    Console.WriteLine(set.Contains(x));   // Probably *also* false, because the hash set looks for x in the wrong bucket!
