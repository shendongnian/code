        public static IEnumerable<List<T>> GroupSequential<T>(this IEnumerable<T> source, int groupSize, bool includePartialGroups = true)
        {
            if (groupSize < 1)
                throw new ArgumentOutOfRangeException("groupSize", groupSize, "Must have groupSize >= 1.");
            var group = new List<T>(groupSize);
            foreach (var item in source)
            {
                group.Add(item);
                if (group.Count == groupSize)
                {
                    yield return group;
                    group = new List<T>(groupSize);
                }
            }
            if (group.Any() && (includePartialGroups || group.Count == groupSize))
                yield return group;
        }
