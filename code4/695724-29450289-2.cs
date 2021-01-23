    public class ObjectListAdapter<T> : System.Collections.ObjectModel.Collection<T>, IList<object>
    {
        public ObjectListAdapter(IList<T> wrappedList)
            : base(wrappedList)
        {
        }
        public int IndexOf(object item)
        {
            return base.IndexOf((T)item);
        }
        public void Insert(int index, object item)
        {
            base.Insert(index, (T)item);
        }
        public new object this[int index]
        {
            get
            {
                return base[index];
            }
            set
            {
                base[index] = (T)value;
            }
        }
        public void Add(object item)
        {
            base.Add((T)item);
        }
        public bool Contains(object item)
        {
            return base.Contains((T)item);
        }
        public void CopyTo(object[] array, int arrayIndex)
        {
            this.Cast<object>().ToArray().CopyTo(array, arrayIndex);
        }
        public bool IsReadOnly
        {
            get { return false; }
        }
        public bool Remove(object item)
        {
            return base.Remove((T)item);
        }
        public new IEnumerator<object> GetEnumerator()
        {
            return this.Cast<object>().GetEnumerator();
        }
    }
