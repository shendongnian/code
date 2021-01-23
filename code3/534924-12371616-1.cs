    OrderedDictionary mylist = new OrderedDictionary(); 
    mylist.Add(1, "Hello"); 
    mylist.Add(4, "World"); 
    mylist.Add(7, "Foo"); 
    mylist.Add(9, "Bar");
    
    int key = 7;
    Console.WriteLine("value: " + mylist[key as object]);
    var nextKeys = mylist.Keys.Cast<int>().Where(i => i > key);
    if (nextKeys.Count() == 0)
        Console.WriteLine("next value: (none)");
    else
        Console.WriteLine("next value: " + mylist[nextKeys.Min() as object]);
