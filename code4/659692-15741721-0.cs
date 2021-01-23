    Dictionary<string, uint> oSomeDictionary = new Dictionary<string, uint>();
    
    oSomeDictionary.Add("dart1", 1);
    oSomeDictionary.Add("card2", 1);
    oSomeDictionary.Add("dart3", 2);
    oSomeDictionary.Add("card4", 0);
    oSomeDictionary.Add("dart5", 3);
    oSomeDictionary.Add("card6", 1);
    oSomeDictionary.Add("card7", 0);
    
    var yourlist = oSomeDictionary.Where(n => n.Key.StartsWith("card") && n.Value > 0);
    foreach (var i in yourlist)
    {
        Console.WriteLine("Key: {0}, Value: {1}", i.Key, i.Value);
    }
