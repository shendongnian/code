    public class Foo
    {
        public Foo() { }
        
        public Foo(int item)
        {
            Item = item;
        }
    
        public int Item { get; set; }
    }
    var foos = new List<Foo>
                    {
                        new Foo(1),
                        new Foo(2),
                        new Foo(3),
                        new Foo(4),
                        new Foo(5),
                        new Foo(6)
                    };
    
    foreach (var foo in foos)
    {
        if(foo.Item == 3)
        {
            var startIndex = foos.IndexOf(foo) + 1;
            var matchedFooIndex = foos.FindIndex(startIndex, f => f.Item % 3 == 0);
            if(matchedFooIndex >= startIndex) // Make sure we found a match
                foos[matchedFooIndex].Item = 10;
        }
    }
