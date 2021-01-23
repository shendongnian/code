    List<MyOtherClass> MyCoolDataSource = new List<MyOtherClass>();
    	
    MyCoolDataSource.Add(new MyOtherClass { CoolClass = new MyCoolClass { Field1 = "Z", Field2 = 123 } });
    MyCoolDataSource.Add(new MyOtherClass { CoolClass = new MyCoolClass { Field1 = "A", Field2 = 3 } });
    MyCoolDataSource.Add(new MyOtherClass { CoolClass = new MyCoolClass { Field1 = "J", Field2 = 4 } });
    MyCoolDataSource.Add(new MyOtherClass { CoolClass = new MyCoolClass { Field1 = "K" } });
    	
    var sortedByField1 = MyCoolDataSource.OrderBy(e => e.CoolClass.Field1).ToList();
    var sortedByField2 = MyCoolDataSource.OrderBy(e => e.CoolClass.Field2).ToList();
    	
    //display
    Console.WriteLine("Ordered by first filed");
    sortedByField1.ForEach(e => {
    	Console.WriteLine(string.Format("Field 1: {0}, Field 2: {1}", e.CoolClass.Field1, e.CoolClass.Field2));
    });
    	
    Console.WriteLine("Ordered by second filed");
    sortedByField2.ForEach(e => {
    	Console.WriteLine(string.Format("Field 1: {0}, Field 2: {1}", e.CoolClass.Field1, e.CoolClass.Field2));
    });
