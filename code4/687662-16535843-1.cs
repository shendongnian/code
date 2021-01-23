     var bla = GetNameValueCollectionSection("MyCustomTag", @".\XMLFile1.xml");
    for (int i = 0; i < bla.Count; i++)
    {
        Console.WriteLine(bla[i] + " = " + bla.Keys[i]);
    }
