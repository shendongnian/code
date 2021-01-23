    var locItems = new Dictionary<int, List<string>>();
    
    List<string> items = new List<string>() { "item1", "Item2", "item3" };
    locItems.Add(1, items);
    // Get all items from location 1 ...
    List<string> items = locItems[1];
    foreach(string s in items)
        Console.WriteLine(s);
    // Now add another item to the list
    items.Add("Some new item");
    
    // Since this is by ref - the list in the dict will be modified 
    // so you don't need to worry about re-adding it to the dict
