    var counts = emptyArray.GroupBy(x => x)
                           .Select(x => new {Key = x.Key, Count = x.Count()});
    foreach (var p in counts)
    {
        Console.WriteLine("The number of times {0} was inputed was {1}", p.Key.AsWord(), p.Count);
    }
    public static class Extensions
    {
        public static string AsWord(this int num)
        {
            switch (num) 
            {
                case 1: return "ONE";  
                case 2: return "TWO";
                // ...
        }
    }
