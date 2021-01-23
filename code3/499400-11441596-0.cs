        private static IEnumerable<int> Merge(IEnumerable<int> enum1, IEnumerable<int> enum2)
        {
            IEnumerator<int> e1 = enum1.GetEnumerator();
            IEnumerator<int> e2 = enum2.GetEnumerator();
            bool remaining1 = e1.MoveNext();
            bool remaining2 = e2.MoveNext();
            while (remaining1 || remaining2)
            {
                if (remaining1 && remaining2)
                {
                    if (e1.Current > e2.Current)
                    {
                        yield return e2.Current;
                        remaining2 = e2.MoveNext();
                    }
                    else
                    {
                        yield return e1.Current;
                        remaining1 = e1.MoveNext();
                    }
                }
                else if (remaining2)
                {
                    yield return e2.Current;
                    remaining2 = e2.MoveNext();
                }
                else
                {
                    yield return e1.Current;
                    remaining1 = e1.MoveNext();
                }
            }
        }
