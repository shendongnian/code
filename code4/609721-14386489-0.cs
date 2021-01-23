    Action MonsterAction = 
        () => Console.WriteLine("MonsterAction");
    Action MonsterDeath = 
        () => Console.WriteLine("MonsterDeath");
    
    // action stream
    var monsterAction = Observable
        .Interval(TimeSpan.FromMilliseconds(250))
        .Do(_ => MonsterAction());
    
    // death stream
    var monsterDeath = Observable
        .Interval(TimeSpan.FromMilliseconds(1000))
        .Do(_ => MonsterDeath());
        
    // act, act, act, act + die, act, act, ...
    var obs = monsterAction.Merge(monsterDeath);
    
    // "warm up" the cold observable
    var hotObs1 = obs.Publish();
    
    using(var conn = hotObs1.Connect())
    using(var x = hotObs1.Subscribe(evt => Console.WriteLine(evt)))
    {
        Console.ReadLine();
    }
