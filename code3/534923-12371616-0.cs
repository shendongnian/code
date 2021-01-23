    OrderedDictionary mylist = new OrderedDictionary(); 
    mylist.Add(1, "Hello"); 
    mylist.Add(4, "World"); 
    mylist.Add(7, "Foo"); 
    mylist.Add(9, "Bar");
    
    int key = 7;
    Console.WriteLine("value: " + mylist[key as object]);
    int nextKey = mylist.Keys.Cast<int>().Where(i => i > key).DefaultIfEmpty(-1).Min();
    if (nextKey == -1)
        Console.WriteLine("next value: (none)");
    else
        Console.WriteLine("next value: " + mylist[nextKey as object]);
