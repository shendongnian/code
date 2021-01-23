        static IEnumerable<IEnumerable<T>> Batch<T>(IEnumerable<T> xs, int n)
        {
            return Unfold(ys =>
                {
                    var head = ys.Take(n);
                    var tail = ys.Skip(n);
                    return head.Take(1).Select(_ => Tuple.Create(tail, head));
                },
                xs);
        }
