    using System.Linq;
    
    List<int> ids = //
    
    foreach(var grp in ids.GroupBy(i => i))
    {
        Console.WriteLine("{0} : {1}", grp.Key, grp.Count());
    }
