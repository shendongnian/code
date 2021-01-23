    var str = "abc cccdd";
    
    var group = from c in str
                group c by c into g
                select g;
    
    foreach(var g in group)
    {
        Console.WriteLine(string.Format("{0}\t{1}", g.Key, g.Count()));
    }
