    var list = data.Batch(N).Select(x => x.ToArray()).ToList();
    list.Sort(new ArrayComparer());
-
    public class ArrayComparer : IComparer<IEnumerable<byte>>
    {
        public int Compare(IEnumerable<byte> x, IEnumerable<byte> y)
        {
            var xenum = x.GetEnumerator();
            var yenum = y.GetEnumerator();
            while (xenum.MoveNext() && yenum.MoveNext())
            {
                if (xenum.Current != yenum.Current) 
                       return xenum.Current - yenum.Current;
            }
            return 0;
        }
    }
