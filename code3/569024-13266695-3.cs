    public interface IExpirable
    {
        /// <summary>
        /// This is the time at which the object was created.
        /// </summary>
        DateTime Time
        {
            get;
        }
    }
    public class ExpirableList<T> : IList<T> where T : IExpirable
    {
        private volatile List<T> collection = new List<T>();
        private Timer timer;
        public int Interval
        {
            get { return timer.Interval; }
            set { timer.Interval = value; }
        }
        private TimeSpan expiration;
        public TimeSpan Expiration
        {
            get { return expiration; }
            set { expiration = value; }
        }
        /// <summary>
        /// Define a list that automaticly remove expired objects.
        /// </summary>
        /// <param name="_interval"></param>
        /// The interval at which the list test for old objects.
        /// <param name="_expiration"></param>
        /// The TimeSpan an object stay valid inside the list.
        public ExpirableList(int _interval, TimeSpan _expiration)
        {
            timer = new Timer();
            timer.Interval = _interval;
            timer.Tick += new EventHandler(Tick);
            timer.Start();
        }
        private void Tick(object sender, EventArgs e)
        {
            for (int i = collection.Count - 1; i >= 0; i--)
            {
                IExpirable expirable = collection[i];
                if ((DateTime.Now - expirable.Time) >= expiration)
                {
                    collection.RemoveAt(i);
                }
            }
        }
        #region IList Implementation
        public T this[int index]
        {
            get { return collection[index]; }
            set { collection[index] = value; }
        }
        public IEnumerator<T> GetEnumerator()
        {
            return collection.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return collection.GetEnumerator();
        }
        public void Add(T item)
        {
            collection.Add(item);
        }
        public int Count
        {
            get { return collection.Count; }
        }
        public bool IsSynchronized
        {
            get { return true; }
        }
        public bool IsReadOnly
        {
            get { return false; }
        }
        public void CopyTo(T[] array, int index)
        {
            collection.CopyTo(array, index);
        }
        public bool Remove(T item)
        {
            return collection.Remove(item);
        }
        public void RemoveAt(int i)
        {
            collection.RemoveAt(i);
        }
        public bool Contains(T item)
        {
            return collection.Contains(item);
        }
        public void Insert(int index, T item)
        {
            collection.Insert(index, item);
        }
        public int IndexOf(T item)
        {
            return collection.IndexOf(item);
        }
        public void Clear()
        {
            collection.Clear();
        }
        #endregion
    }
