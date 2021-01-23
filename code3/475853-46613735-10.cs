    string csv = @"Id, Name, 
    1, Tom, NY
    2, Mark, NJ
    3, Lou, FL
    4, Smith, PA
    5, Raj, DC
    ";
    
    StringBuilder sb = new StringBuilder();
    using (var p = ChoCSVReader.LoadText(csv)
        .WithField("Id", position: 1)
        .WithField("Name", position: 2)
        .WithField("City", position: 3)
        .WithFirstLineHeader(true)
        )
    {
        using (var w = new ChoJSONWriter(sb))
            w.Write(p);
    }
    
    Console.WriteLine(sb.ToString());
