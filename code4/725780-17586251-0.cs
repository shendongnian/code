    var commons = list1.Select(x => list2.Select(x.Intersect).ToArray()).ToArray();
    Console.WriteLine(commons[0][0]); // Commons between list1[0] and list2[0]
    Console.WriteLine(commons[0][1]); // Commons between list1[0] and list2[1]
    Console.WriteLine(commons[3][0]); // Commons between list1[3] and list2[0]
    Console.WriteLine(commons[3][0].Length); // Number of commons between [3] and [0]
