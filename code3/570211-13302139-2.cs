    var max =
        (from pair in dictionary
        select pair.Value).Max()
    for (int i = max; i > -1; i--)
    {
        var items =
            from pair in dictionary
            where pair.Value == i
            select pair.Key;
        if (items.Count() > 0)
        {
            Console.WriteLine("\nWords occuring " + i.ToString() +" times");
            int count = 0;
            foreach(var item in items)
            {
                if (count == 4)
                {
                    Console.WriteLine("");
                    count = 0;
                }
                else
                {
                    count++;
                }
                Console.Write(item + "\t");
            }
        }	
    }
