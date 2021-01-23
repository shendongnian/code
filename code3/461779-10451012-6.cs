        private static IEnumerable<T> MergeSorted<T>(IEnumerable<IEnumerable<T>> sortedInts) where T : IComparable<T>
        {
            var enumerators = new List<IEnumerator<T>>(sortedInts.Select(ints => ints.GetEnumerator()).Where(e => e.MoveNext()));
            enumerators.Sort((e1, e2) => e1.Current.CompareTo(e2.Current));
            while (enumerators.Count > 1)
            {
                yield return enumerators[0].Current;
                if (enumerators[0].MoveNext())
                {
                    if (enumerators[0].Current.CompareTo(enumerators[1].Current) == 1)
                    {
                        var tmp = enumerators[0];
                        enumerators[0] = enumerators[1];
                        enumerators[1] = tmp;
                    }
                }
                else
                {
                    enumerators.RemoveAt(0);
                }
            }
            do
            {
                yield return enumerators[0].Current;
            } while (enumerators[0].MoveNext());
        }
