    var sourceA = new Subject<string>();    
    var sourceB = Observable.Range(0, 5).Select(i => "B" + i.ToString());    
    var sourceC = Observable.Range(0, 5).Select(i => "C" + i.ToString());    
    
    var query = sourceA.Amb(sourceB).Amb(sourceC);
    
    using(query.Subscribe(Console.WriteLine))
    {
        Console.ReadLine();
    }            
