    public static class LinqEx
    {
        public static void ToLists<T, T1, T2>(this IEnumerable<T> source, SelectorDst<T, T1> selectorDst1, SelectorDst<T, T2> selectorDst2)
        {
            selectorDst1.List.AddRange(source.Select(selectorDst1.Selector));
            selectorDst2.List.AddRange(source.Select(selectorDst2.Selector));
        }
    }
    public class SelectorDst<T, TList>
    {
        public readonly List<TList> List;
        public readonly Func<T, TList> Selector;
        public SelectorDst(List<TList> list, Func<T, TList> selector)
        {
            this.List = list;
            this.Selector = selector;
        }
    }
    ... Some place in the code
    var points = new List<Point>();
    var xs = new List<int>();
    var ys = new List<int>();
    points.ToLists(new SelectorDst<Point, int>(xs, p => p.X),
                   new SelectorDst<Point, int>(ys, p => p.Y));
