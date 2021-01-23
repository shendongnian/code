    interface IBase
    {
        void Overloaded(Expression<Func<int, int>> e);
    }
    interface IDerived : IBase
    {
        void Overloaded(Func<int, int> d);
    }
    class C : IDerived
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
