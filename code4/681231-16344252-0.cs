    public class Foo
    {
        public Foo() { }
        
        public Foo(int item)
        {
            Item = item;
        }
    
        public int Item { get; set; }
    }
    var items = new List<Foo>{ new Foo(1), new Foo(2), new Foo(3), new Foo(4), new Foo(5), new Foo(6)};
    
    foreach (var item in items)
    {
        if(item.Item == 3)
        {
            var startIndex = items.IndexOf(item) + 1;
            var otherItem = items.FindIndex(startIndex, i => i.Item % 3 == 0);
            items[otherItem].Item = 10;
        }
    }
