    class A
    {
        public string PropertyA { get; set; }
        
        public override string ToString() { return this.PropertyA; }
    }
    
    class B : A
    {
        public string PropertyB { get; set; }
        
        public override string ToString() { return string.Format("{0} - {1}", this.PropertyA, this.PropertyB); }
    }
    
    var aList = new List<A>();
    var bList = new List<B>();
    
    for (int i = 0; i < 10; i++)
    {
        aList.Add(new A() { PropertyA = string.Format("A - {0}", i) });
        bList.Add(new B() { PropertyA = string.Format("B::A - {0}", i), PropertyB = string.Format("B::B - {0}", i) });
    }
    
    // now list the current state of the two lists
    for (int i = 0; i < 10; i++)
    {
        Console.WriteLine(aList[i]);
        Console.WriteLine(bList[i]);
    }
    
    Console.WriteLine();
    Console.WriteLine();
    
    // now merge the lists and print that result
    var newList = bList.Concat(aList.Select(a => new B() { PropertyA = a.PropertyA, PropertyB = "Created by system." }));
    foreach (var item in newList)
    {
        Console.WriteLine(item);
    }
