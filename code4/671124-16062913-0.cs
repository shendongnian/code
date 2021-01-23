    var lines = File.ReadAllLines(@"C:\items.txt");
    var points = new List<Tuple<int, int>>();
    var items = lines.SelectMany(ln => ln.Split(new[] {' '}).Select(n => Convert.ToInt32(n)))
                     .ToList();
    for (int i = 0; i < items.Count(); i+=2)
    {    
        int second = (i + 1) < items.Count() ? items[ i + 1] : Int32.MinValue;                
        points.Add(Tuple.Create(items[i], second));
    }
