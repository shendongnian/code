    class A
    {
        public string X { get; set; }
        public A SetX(string x)
        {
            this.X = x;
            return this;
        }
    }
    class B : A
    {
        public string Y { get; set; }
        public new B SetX(string x)
        {
            return (B) base.SetX(x);
        }
        public B SetY(string y)
        {
            this.Y = y;
            return this;
        }
    }
