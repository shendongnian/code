    void Main()
    {
        Dictionary<int, IList<IDriller>> allDrillTypes = 
            new Dictionary<int, IList<IDriller>>()
        {
            { 13, new List<IDriller>() { new Driller1() } },
            { 14, new List<IDriller>() { new Driller2() } },
        };
        
        Console.WriteLine(allDrillTypes[13][0].SomeCommonProperty); // prints 123
        Console.WriteLine(allDrillTypes[14][0].SomeCommonProperty); // prints 456
    }
    
    interface IDriller
    {
        int SomeCommonProperty { get; }
    }
    
    class Driller1 : IDriller
    {
        public int SomeCommonProperty { get { return 123; } }
    }
    
    class Driller2 : IDriller
    {
        public int SomeCommonProperty { get { return 456; } }
    }
