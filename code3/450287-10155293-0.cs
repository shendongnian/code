    var x = new Int16_2d { a = 1, b = 2 };
    var set = new HashSet<Int16_2D> { x };
    var y = new Int16_2d { a = 1, b = 2 };
    Console.WriteLine(x.Contains(y));   // True
    x.a = 3;
    Console.WriteLine(x.Contains(y));   // False
    Console.WriteLine(x.Contains(x));   // Probably *also* false, because the hash set looks for x in the wrong bucket!
