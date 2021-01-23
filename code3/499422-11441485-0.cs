    class Foo<T>
    {
        public IEnumerable<T> GetList()
        {
            return new List<T>();
        }
    
        public IEnumerable<T> GetStack()
        {
            return new Stack<T>();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Foo<int> foo = new Foo<int>();
            IEnumerable<int> list = foo.GetList();
            IEnumerable<int> stack = foo.GetStack();
    
            Foo<string> foo1 = new Foo<string>();
            IEnumerable<string> list1 = foo1.GetList();
            IEnumerable<string> stack1 = foo1.GetStack();
        }
    }
