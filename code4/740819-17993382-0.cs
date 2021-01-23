    public class A
    {
        public A()
        {
            this.Bs = new List<B>();
            this.Bs.Add(new B { Name = "a", Value = "aaa" });
            this.Bs.Add(new B { Name = "b", Value = "bbb" });
            this.Bs.Add(new B { Name = "c", Value = "ccc" });
        }
        public List<B> Bs { get; set; }
        public B B(string name)
        {
            var match = this.Bs.FirstOrDefault(b => b.Name == name);
            if (match != null)
                return match;
            return null;
        }
    }
    public class B
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
