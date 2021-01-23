    public class Foo
    {
        public const string Bar = "SomeString";
    
        public string Bar
        {
            get { return Foo.Bar; }
        }
    }
