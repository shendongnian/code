    class Foo : IMutableFoo {
        // IFoo is implemented explicitly
        // "this" is of type Foo, and since IMutableFoo is implemented
        // implicitly below, this.Id accesses the Id declared in IMutableFoo
        Int32 IFoo.Id { get { return this.Id; } }
    
        // IMutableFoo is implemented implicitly
        public Int32 Id { get; set; }
    }
