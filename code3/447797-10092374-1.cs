    struct S
    {
        readonly int x;
        public S(int x) { this.x = x; }
        public void M(ref S s)
        {
            Console.WriteLine(this.x);
            s = new S(this.x + 1);
            Console.WriteLine(this.x);
        }
    }
