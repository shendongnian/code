        protected void bar1(int a, int b, int c)
        {
            Console.WriteLine("a={0}, b={1}, c={2}", a, b, c);
        }
        protected void bar2(int a, int b, int c, int d)
        {
            Console.WriteLine("a={0}, b={1}, c={2}, d={3}", a, b, c, d);
        }
        public void foo(Action<int, int, int> bar)
        {
            int a = 1;
            int b = 2;
            int c = 3;
            bar1(a, b, c);
        }
        public void foo(Action<int, int, int, int> bar)
        {
            int a = 1;
            int b = 2;
            int c = 3;
            int d = 4;
            bar2(a, b, c, d);
        }
        public void main()
        {
            if (condition)
                foo(bar1);
            else
                foo(bar2);
        }
