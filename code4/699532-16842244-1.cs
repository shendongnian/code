    class Point3D {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
    }
    ...
    // Construct sample objects
    var p1 = new Point3D { X = 1, Y = 2, Z = 3};
    var p2 = new Point3D { X = 1, Y = 2, Z = 3 };
    var p3 = new Point3D { X = 1, Y = 3, Z = 1 };
    // Get a comparator
    var cmp = MakeComparator<Point3D>();
    // Use the comparator to compare objects to each other
    Console.WriteLine(cmp(p1, p2));
    Console.WriteLine(cmp(p2, p3));
