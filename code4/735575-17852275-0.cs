    class Foo : IFoo
    {
        readonly string name;
        public Foo(string name)
        {
            this.name = name;
        }
        string IFoo.Message
        {
            get
            {
                return "Hello from " + name;
            }
        }
    }
    // these attributes make it work
    // (the guid is purely random)
    [ComImport, CoClass(typeof(Foo))]
    [Guid("d60908eb-fd5a-4d3c-9392-8646fcd1edce")]
    interface IFoo
    {
        string Message {get;}
    }
    //and then somewhere else:
    IFoo foo = new IFoo(); //no errors!
