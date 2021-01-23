    interface IFoo {
        string Name { get; set; }
        int Age { get; set; }
        void Hydrate(string xml);
    }
    
    class Foo : IFoo {
        public string Name { get; set; }
        public int Age { get; set; }
    
        public void Hydrate(string xml) {
            var xmlReader = ...etc...;
            Name = xmlReader.Read(...whatever...);
            ...etc...;
            Age = xmlReader.Read(...whatever...);
        }
    }
    void Main() {
        IFoo f = new Foo();
        f.Hydrate(someXml);
    }
