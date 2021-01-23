    public enum myNums
    {
        Alpha = 1,
        Beta = 10,
        Gamma = 100
    }
    
    void Main()
    {
    
        var value  = System.Enum.GetValues( typeof( myNums ) )
                               .OfType<myNums>()
                               .Sum (n => (int)n);
    
        Console.WriteLine ( value ); // 111
    
    }
    
    // Define other methods and classes here
