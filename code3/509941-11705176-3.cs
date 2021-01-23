    class CombinedLists<T> : IEnumerable<T> // Add more interfaces here.
                                            // Maybe IList<T>, but how should it work?
    {
        private List<List<T>> lists = new List<List<T>>();
    
        public void AddList(List<T> list)
        {
            lists.Add(list);
        }
    
        public IEnumerator<T> GetEnumerator()
        {
            return lists.SelectMany(x => x).GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public bool Remove(T t)
        {
            foreach (List<T> list in lists)
            {
                if (list.Remove(t)) { return true; }
            }
            return false;
        }
        // Implement the other methods.
    }
