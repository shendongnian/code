    class Class2
    {
        class ClosureClass
        {
            public foo item; // yes I'm a public field
            public bool Predicate(bar x)
            {
                return x.prop1 == item.A && x.prop2 == item.B;
            }
        }
        public static void DoSomeWork(foo item, List<bar> bList)
        {
            var ctx = new ClosureClass { item = item };
            var query = bList.Where(ctx.Predicate).ToList();
    
            if (query.Any()) {
                DoSomethingElse();
            }
        }
        static void DoSomethingElse() { }
    }
