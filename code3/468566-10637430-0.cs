    public class CustomList<T> : IList<T> where T : CustomClass
    {
        private List<T> innerlist;
        public void Add(T item)
        {
            if(innerlist.Any(a => a.Name == item.Name)))
                innerlist.Add(item);
        }
    }
