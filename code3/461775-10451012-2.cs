        private static T[] MergeSorted<T>(IEnumerable<T[]> sortedInts) where T : IComparable<T>
        {
            var results = new List<T[]>(sortedInts);
            while (results.Count > 1)
            {
                for (var x = 0; x < results.Count; x++)
                {
                    if (results.Count == 0 || x == results.Count - 1)
                    {
                        continue;
                    }
                    var res = new List<T>(results[x]);
                    var index = 0;
                    for (var j = 0; j < results[x + 1].Length; j++)
                    {
                        for (; index < res.Count; index++)
                        {
                            if (results[x + 1][j].CompareTo(res[index]) <= 0)
                            {
                                break;
                            }
                        }
                        res.Insert(index++, results[x + 1][j]);
                    }
                    results.RemoveAt(x);
                    results[x] = res.ToArray();
                }
            }
            return results[0];
        }
