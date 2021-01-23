    int x = 9;
    List<string> list = new List<string> {};
    
    for (int i = 0; i < x; i++)
    {
        list.Add("a");
        list.Add("b");    
    }
    // verify    
    foreach (var item in list)
    {
        Console.WriteLine(item);    
    }
