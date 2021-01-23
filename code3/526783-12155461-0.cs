    internal class SCO : IVotable
    {
        protected static List<T> SortedCollection<T>
            (SPListItemCollection items, ListSortType sortType, List<Vote> votes,
            Func<SPListItem, List<Vote>, T> factory) where T : IVotable
        {
            var returnlist = new List<T>();
            Type genericType = typeof(T);
            for (int i = 0; i < items.Count; i++)
                returnlist.Add(factory(items[i], votes));
            // etc.
        }
    }
    class ChildClass : SCO
    {
        public static List<ChildClass> SortedCollection
            (SPListItemCollection items, ListSortType sortType, List<Vote> votes)
        {
            return SCO.SortedCollection<ChildClass>(
                items, sortType, votes, (i, vs) => new ChildClass(i, vs));
        }
    }
