    void Copy(FooBar source, FooBar target)
    {
        source.MapTo(target, (s,t) => t.Foo = s.Foo, 
                             (s,t) => t.Bar = s.Bar, 
                             (t,s) => t.Baz = s.Baz);
    }
    class FooBar
    {
        public string Foo { get; set; }
        public string Bar { get; set; }
        public string Baz { get; set; }
    }
