    var max =
        (from pair in dictionary
        select pair.Value).Max()
    for (int i = 0; i < max; i++)
    {
        var items =
            from pair in dictionary
            where pair.Value == i
            select pair.Key;
        if (items.Count() > 0)
        {
            Console.WriteLine("Words occuring " + i.ToString() +" times");
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
