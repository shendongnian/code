    public class UniqueList<T> : IList<T>
    {
        private readonly List<T> list=new List<T>();
        private readonly HashSet<T> set=new HashSet<T>();
        public IEnumerator<T> GetEnumerator()
        {
            return list.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public void Add(T item)
        {
            if(set.Add(item))
            {
                list.Add(item);
            }
        }
        public void Clear()
        {
            set.Clear();
            list.Clear();
        }
        public bool Contains(T item)
        {
            return set.Contains(item);
        }
        public void CopyTo(T[] array, int arrayIndex)
        {
            list.CopyTo(array,arrayIndex);
        }
        public bool Remove(T item)
        {
            if(set.Remove(item))
            {
               list.Remove(item);
                return true;
            }
            return false;
        }
        public int Count { get { return list.Count; } }
        public bool IsReadOnly { get { return false; } }
        public int IndexOf(T item)
        {
            return list.IndexOf(item);
        }
        public void Insert(int index, T item)
        {
            if(set.Add(item))
            {
                list.Insert(index, item);
            }
        }
        public void RemoveAt(int index)
        {
            T item = list[index];
            set.Remove(item);
            list.RemoveAt(index);
        }
        public T this[int index]
        {
            get { return list[index]; }
            set {
                T item = list[index];
                set.Remove(item);
                if(set.Add(value))
                {
                    list[index] = value;    
                }
                else
                {
                    set.Add(item);
                    throw new Exception();
                }
                
                
            }
        }
    }
