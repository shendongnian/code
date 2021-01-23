    int[] daysId = new int[] { 1, 3,48,127 };
    Dictionary<int, List<DaysOfTheWeek>> result = new Dictionary<int, List<DaysOfTheWeek>>();
    foreach (int id in daysId)
    {
        result[id] = new List<DaysOfTheWeek>();
        BitArray ba = new BitArray(new int[]{id});
        for (int i=0;i<ba.Length;i++)
        {
            if (ba[i])
            {
                result[id].Add((DaysOfTheWeek)(1 << i));
                Console.WriteLine((DaysOfTheWeek)(1 << i));
             }                    
         }
        Console.WriteLine("id-" + id + " > " + (DaysOfTheWeek)id);                
    }
    Console.ReadKey();
