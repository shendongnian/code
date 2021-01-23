    public static IEnumerable<T> Leave<T>(this ICollection<T> src, int drop) => src.Take(src.Count - drop);
    public static IEnumerable<T> Leave<T>(this IEnumerable<T> src, int drop) {
        IEnumerable<T> IEnumHelper() {
            using (var esrc = src.GetEnumerator()) {
                var buf = new Queue<T>();
                while (drop-- > 0)
                    if (esrc.MoveNext())
                        buf.Enqueue(esrc.Current);
                    else
                        break;
                while (esrc.MoveNext()) {
                    buf.Enqueue(esrc.Current);
                    yield return buf.Dequeue();
                }
            }
        }
        return (src is ICollection<T> csrc) ? csrc.Leave(drop) : IEnumHelper();
    }
