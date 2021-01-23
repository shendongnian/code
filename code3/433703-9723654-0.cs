    foreach(var group in groupedData)
    {
       Console.WriteLine("Period: {0}", group.Key);
       foreach(var item in group)
          Console.WriteLine("   Adjustment: {0}", item.Adjustment);
    }
