    public void Test_Concat2()
    {
        IEnumerable<Iinterface> bars = new List<Bar>();
        IEnumerable<Iinterface> foos = new List<Foo>();
   
        IEnumerable<Iinterface> concats = bars.Concat(foos);
    }
