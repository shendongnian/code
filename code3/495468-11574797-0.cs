    var collection1 = new ArrayList() { 1, 2, 3 };
    var collection2 = new ArrayList() { 1, 2, 4, 5 };
    var mergedList = new ArrayList();
    mergedList.AddRange(collection1);
    mergedList.AddRange(collection2.ToArray().Where(item => !collection1.ToArray().Contains(item)).ToList());
    Console.WriteLine(String.Join(", ", mergedList.ToArray()));
    Console.ReadLine();
