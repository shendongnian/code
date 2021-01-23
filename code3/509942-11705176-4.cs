    List<string> list1 = new List<string> { "a", "b", "c" };
    List<string> list2 = new List<string> { "1", "2", "3" };
    CombinedLists<string> c = new CombinedLists<string>();
    c.AddList(list1);
    c.AddList(list2);
    c.Remove("a");
    c.Remove("1");
    foreach (var x in c) { Console.WriteLine(x); }
    Console.WriteLine(list1.Count);
    Console.WriteLine(list2.Count);
