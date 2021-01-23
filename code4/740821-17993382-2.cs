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
        public B B(int index)
        {
            if (this.Bs != null && this.Bs[index] != null)
                return this.Bs[index];
             
            return null;
        }
    }
    public class B
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
