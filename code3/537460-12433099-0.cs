    var urgentLocations = 
                   (   from m in Stores
                       group m by m.Location into g
                       where g.Min(m => m.Urgency) < 14
                       select new {Name = g.Key, Stores = g.OrderBy(m=>m.Urgency).ToList()})
                   .OrderBy (g=>g.Stores, new LocationComparer())
                   .ToList();
    public class LocationComparer : IComparer<List<Machine>>
    {
        public int Compare(List<Store> source1, List<Store> source2)
        {
            var reduced1 = from m in source1
                            group m by m.Urgency into g
                            orderby g.Key
                            select g.Key - (g.Count() - 1) * .0000001;
            var reduced2 = from m in source2
                            group m by m.Urgency into g
                            orderby g.Key
                            select g.Key - (g.Count() - 1) * .0000001;
            return SequenceCompare(reduced1, reduced2);
        }
        // adapted from http://stackoverflow.com/a/2811805/126352 but modified so that 
        // shorter sequences are sorted last
        public int SequenceCompare<T>(IEnumerable<T> source1, IEnumerable<T> source2)
        {
            // You could add an overload with this as a parameter 
            IComparer<T> elementComparer = Comparer<T>.Default;
            using (IEnumerator<T> iterator1 = source1.GetEnumerator())
            using (IEnumerator<T> iterator2 = source2.GetEnumerator())
            {
                while (true)
                {
                    bool next1 = iterator1.MoveNext();
                    bool next2 = iterator2.MoveNext();
                    if (!next1 && !next2) // Both sequences finished 
                    {
                        return 0;
                    }
                    if (!next1) // Only the first sequence has finished
                    {
                        return 1;
                    }
                    if (!next2) // Only the second sequence has finished 
                    {
                        return -1;
                    }
                    // Both are still going, compare current elements 
                    int comparison = elementComparer.Compare(iterator1.Current,
                                                     iterator2.Current);
                    // If elements are non-equal, we're done 
                    if (comparison != 0)
                    {
                        return comparison;
                    }
                }
            }
        }
    }
