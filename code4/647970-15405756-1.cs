        public static IEnumerable<T> Splice<T>(params List<T>[] lists)
        {
            var max = lists.Max(list => list.Count());
            for (int i = 0; i < max; i++)
            {
                foreach (var list in lists)
                {
                    if (i < list.Count)
                    {
                        yield return list[i];
                    }
                }
            }
        }
