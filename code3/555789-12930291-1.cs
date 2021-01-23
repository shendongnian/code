    void Main()
    {
        var driller1 = new DrillerWhichYouCannotChange1();
        var driller2 = new DrillerWhichYouCannotChange2();
    
        var allDrillTypes = new Dictionary<int, IList<IDriller>>()
        {
            { 13, new List<IDriller>() { new DrillerWhichYouCannotChange1Adapter(driller1) } },
            { 14, new List<IDriller>() { new DrillerWhichYouCannotChange2Adapter(driller2) } },
        };
        
        Console.WriteLine(allDrillTypes[13][0].SomeCommonProperty); // prints 123
        Console.WriteLine(allDrillTypes[14][0].SomeCommonProperty); // prints 456
    }
    
    interface IDriller
    {
        int SomeCommonProperty { get; }
    }
    
    class DrillerWhichYouCannotChange1Adapter : IDriller
    {
        private DrillerWhichYouCannotChange1 inner;
    
        public DrillerWhichYouCannotChange1Adapter(DrillerWhichYouCannotChange1 inner)
        {
            this.inner = inner;
        }
    
        public int SomeCommonProperty { get { return this.inner.PropertyX; } }
    }
    
    class DrillerWhichYouCannotChange2Adapter : IDriller
    {
        private DrillerWhichYouCannotChange2 inner;
    
        public DrillerWhichYouCannotChange2Adapter(DrillerWhichYouCannotChange2 inner)
        {
            this.inner = inner;
        }
    
        public int SomeCommonProperty { get { return this.inner.PropertyY; } }
    }
    
    class DrillerWhichYouCannotChange1
    {
        public int PropertyX { get { return 123; } }
    }
    
    class DrillerWhichYouCannotChange2
    {
        public int PropertyY { get { return 456; } }
    }
