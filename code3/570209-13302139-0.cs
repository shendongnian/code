    var max =
        (from pair in dictionary
        select pair.Value).Max()
    for (int i = 0; i < max; i++)
    {
        Console.WriteLine("Words occuring " + i.ToString() +" times");
        var items =
            from pair in dictionary
            where pair.Value == i
            select pair.Key;
        foreach(var item in items)
        {
            Console.Write(item + "\t");
        }	
    }
