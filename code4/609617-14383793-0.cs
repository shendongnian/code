    class FooCollection : List<Foo>, IList<Foo>
    {
        public string Bar { get; set; }        
        //Implement IList, ICollection and IEnumerable members...
    }
