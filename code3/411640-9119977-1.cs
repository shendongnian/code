    public class A {}
    public class ADerived : A {}
    public class B<Ta> where Ta : A
    {
        public Ta a { get; set; }
    }
    public class BDerived<Ta> : B<Ta> where Ta : ADerived {}
    public class Test
    {
        public List<Tb> DoSomething<Tb, Ta>(Ta input) 
            where Tb : B<Ta>, new() 
            where Ta : A, new()
        {
            var list = new List<Tb>();
            var b = new Tb();
            b.a = input;
            list.Add(b);
            return list;
        }
        public int testThis()
        {
            var result = DoSomething<BDerived<ADerived>, ADerived>(new ADerived());
            return result.Count;
        }
    }
