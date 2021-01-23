    static void Main()
    {
        NaturalFood food = GetSomeFood(); // At this point, we don't know the actual type
        food.SomeMethodInBaseClass(); // ok
        
        Fruits f = new Fruits();
        Console.WriteLine(    f.AllList.Apple); // Ok
    
        Vegetable v = new Vegetable ();
        Console.WriteLine(    v.AllList.Potatoe); // Ok
    
    
    }
