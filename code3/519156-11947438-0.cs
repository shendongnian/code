    class Class2
    {
        public static void DoSomeWork(foo item, List<bar> bList)
        {
            var query = bList.Where(x => x.prop1 == item.A && x.prop2 == item.B)
                             .ToList();
    
            if (query.Any())
                DoSomethingElse();
        }
        static void DoSomethingElse() { }
    }
    class foo { public int A { get; set; } public int B { get; set; } }
    class bar { public int prop1 { get; set; } public int prop2 { get; set; } }
