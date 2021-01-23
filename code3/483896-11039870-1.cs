    [ComImport]
    [Guid("175EB158-B655-11E1-B477-02566188709B")]
    [CoClass(typeof(Foo))]
    interface IFoo
    {
        string Bar();
    }
    class Foo : IFoo
    {
        public string Bar()
        {
            return "Hello world"; 
        }
    }
