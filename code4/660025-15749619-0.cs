    dynamic tuple = new ExpandoObject();
    tuple.AttackingTank = new Tank();
    tuple.TargetTank = new Tank();
    
    var mylist = new List<dynamic> { tuple };
    
    //access to items
    Console.WriteLine(mylist[0].AttackingTank);
