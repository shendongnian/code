    class Program
    {
        class Bar
        {
            public Bar(int x)
            {
                Foo = x;
            }
            public int Foo { get; set; }
        }
        class BarComparer : IEqualityComparer<Bar>
        {
            public bool Equals(Bar x, Bar y)
            {
                return x.Foo == y.Foo;
            }
            public int GetHashCode(Bar obj)
            {
                return obj.Foo;
            }
        }
        static void Main(string[] args)
        {
            var list1 = new List<Bar>() { new Bar(10), new Bar(20), new Bar(30)};
            var list2 = new List<Bar>() { new Bar(10),  new Bar(20) };
            var result = list1.Intersect(list2, new BarComparer());
            foreach (var item in result)
            {
                Console.WriteLine(item.Foo);
            }
        }
    }
