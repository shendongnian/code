    public static decimal ExtrapolateFrom(int f, int s, decimal f1, decimal s2, int value)
    {            
        return (s2-f1)/((s-(decimal)f)/(value-(decimal)f))+f1;         
    }
    
    public static decimal ExtrapolateFrom(List<Tuple<int, decimal>> table, int value)
    {
        if(table.Count < 2) throw  new Exception("Not enough values to extrapolate from");
        var index = table.Select((x, i) => new { x, i }).Where(x => x.x.Item1 >= value).Select(x => x.i).FirstOrDefault();
        if (index < 1) index = 1;
        if (index >= table.Count) index = table.Count - 1;
        return ExtrapolateFrom(table[index - 1].Item1, table[index].Item1, table[index - 1].Item2,table[index].Item2, value);
    }
    
    
    private static void Main(string[] args)
    {
        var table = new List<Tuple<int, decimal>> ()
            {
                new Tuple<int, decimal>(0, 0.0M),
                new Tuple<int, decimal>(100, 5.0M),
                new Tuple<int, decimal>(200, 6.0M),
                new Tuple<int, decimal>(300, 9.0M),
                new Tuple<int, decimal>(500, 11.0M),
            };
                
    
        Console.WriteLine(ExtrapolateFrom(table, 50));
        Console.WriteLine(ExtrapolateFrom(table, 400));
    }
