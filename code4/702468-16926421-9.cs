    var map = new MultiKeyLookup<int, string>();
    map.Root = map.CreateNode(
        Tuple.Create(0, map.CreateLeaf("a0")),
        Tuple.Create(1, map.CreateNode(
            Tuple.Create(0, map.CreateLeaf("b0")),
            Tuple.Create(1, map.CreateNode(
                Tuple.Create(0, map.CreateLeaf("c0")),
                Tuple.Create(1, map.CreateLeaf("c1")))),
            Tuple.Create(2, map.CreateLeaf("b2")))),
        Tuple.Create(2, map.CreateLeaf("a2")));
    Console.WriteLine(map.GetValue(new int[] { 0 })); //prints a0
    Console.WriteLine(map.GetValue(new int[] { 0, 0, 4 })); //prints a0
    Console.WriteLine(map.GetValue(new int[] { 1, 0 })); // prints b0
    Console.WriteLine(map.GetValue(new int[] { 1, 1, 0 })); //prints c0
