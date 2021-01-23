        class Program
        {
            static void Main(string[] args)
            {
                List<A> lst = new List<A>();
    
                for (int j = 1; j < 4; j++)
                {
                    var tmp = new A() { Value = j * 1000 };
                    for (int i = 0; i < 150; i++)
                    {
                        tmp.SubItems.Add(new B { Value = i + 1, Parent = tmp });
                    }
                    lst.Add(tmp);
                }
    
                List<B> result = lst.SelectMany(x => x.SubItems.Take(10)).ToList();
            }
        }
    
        public class A
        {
            public A()
            {
                SubItems = new List<B>();
            }
    
            public int Value { get; set; }
            public List<B> SubItems { get; set; }
        }
    
    
        public class B
        {
            public int Value { get; set; }
            public A Parent { get; set; }
        }
