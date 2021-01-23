    class Foo
    {
        public string Bar {get;set;}
    }
    ...
    var foo = new Foo { Bar = "abc" };
    string s = (string)foo; // doesn't compile
