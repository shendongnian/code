    public class Foo
    {
        public int Context;
        public string Data;
    }
    public class Bar
    {
        public int Context;
        public string Data;
    }
    public static IEnumerable<TOutput> JoinTwoModels<T1, T2, TIdent, TOutput>(
        IEnumerable<T1> sourceA,
        IEnumerable<T2> sourceB,
        Func<T1, TIdent> idSelectorA,
        Func<T2, TIdent> idSelectorB,
        Func<T1, TOutput> selectorA,
        Func<T2, TOutput> selectorB)
    {
        var quearyA = sourceA
                .Select(x => new {Value = selectorA(x),Id = idSelectorA(x)});
        var quearyB = sourceB
                .Select(y => new {Value = selectorB(y),Id = idSelectorB(y)})
                .Where(y => quearyA.Select(x => x.Id).Contains(y.Id))
                .Select(y => y.Value);
        return quearyA.Select(x => x.Value).Concat(quearyB);
    }
    private static void Main(string[] args)
    {
        var sourceA = new List<Foo>() {new Foo() {Context = 2, Data = "I'm a Foo"}};
        var sourceB = new List<Bar>() {new Bar() {Context = 2, Data = "I'm a Bar"}};
        var Output1 = sourceA.AsQueryable();
        var Output2 = sourceB.AsQueryable();
        var results = JoinTwoModels(
            Output1,
            Output2,
            (Func<Foo, int>) (x => x.Context),
            (Func<Bar, int>) (x => x.Context),
            (Func<Foo, string>) (x => x.Data),
            (Func<Bar, string>) (x => x.Data));
        foreach (var item in results)
            Console.WriteLine(item);
    }
