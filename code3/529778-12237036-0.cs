    class C
    {
        public void Overloaded(Expression<Func<int, int>> e)
        {
            Console.WriteLine("expression tree");
        }
        public void Overloaded(Func<int, int> d)
        {
            Console.WriteLine("delegate");
        }
    }
