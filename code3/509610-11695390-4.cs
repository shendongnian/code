    var  map = new RangeMap<Color>();
    map.AddPoint(0.0F, Color.Red);
    map.AddPoint(0.5F, Color.Green);
    map.AddPoint(1.0F, Color.Blue);
        		
    Console.WriteLine(map.GetValue(-0.25F).Name);
    Console.WriteLine(map.GetValue( 0.25F).Name);
    Console.WriteLine(map.GetValue( 0.75F).Name);
    Console.WriteLine(map.GetValue( 1.25F).Name);
