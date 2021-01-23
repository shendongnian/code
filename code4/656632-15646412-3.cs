    var p1 = new System.Drawing.Point(10, 20);
    var p2 = p1; // This creates a copy of p1.
    p1.X = 15;
    Console.WriteLine(p1.X); // ==> 15
    Console.WriteLine(p2.X); // ==> 10
