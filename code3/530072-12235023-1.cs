    List<byte[]> result = data.Batch(N)
                              .OrderBy(b => b, new ArrayComparer())
                              .Select(b => b.ToArray())
                              .ToList();
    public class ArrayComparer : IComparer<IEnumerable<byte>>
    {
        public int Compare(IEnumerable<byte> x, IEnumerable<byte> y)
        {
            var xenum = x.GetEnumerator();
            var yenum = y.GetEnumerator();
            while (xenum.MoveNext() && yenum.MoveNext())
            {
                if (xenum.Current != yenum.Current) return xenum.Current - yenum.Current;
            }
            return 0;
        }
    }
