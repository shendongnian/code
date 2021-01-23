    public class A {}
    public class ADerived : A {}
    public class B<T> where T : A
    {
        public T t { get; set; }
    }
    public class BDerived<T> : B<T> where T : A {}
    public class Test
    {
        public List<U> DoSomething<U, T>(T input) 
            where U : B<T>, new() 
            where T : A, new()
        {
            var list = new List<U>();
            var u = new U();
            u.t = input;
            list.Add(u);
            return list;
        }
        public int testThis()
        {
            var result = DoSomething<BDerived<ADerived>, ADerived>(new ADerived());
            return result.Count;
        }
    }
