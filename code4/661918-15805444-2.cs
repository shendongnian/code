    Point a = new Point();
    Console.WriteLine(a); // 0, 0
    a.Change(1, 1);
    Console.WriteLine(a); // 1, 1
    object b = a;
    Console.WriteLine(b); // 1, 1
    a.Change(2, 2);
    Console.WriteLine(a); // 2, 2
    Console.WriteLine(b); // 1, 1
