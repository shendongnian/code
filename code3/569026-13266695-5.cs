    public class ExpirableList<T> : IList<T>
    {
        private volatile List<Tuple<DateTime, T>> collection = new List<Tuple<DateTime,T>>();
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
            expiration = _expiration;
        }
        private void Tick(object sender, EventArgs e)
        {
            for (int i = collection.Count - 1; i >= 0; i--)
            {
                if ((DateTime.Now - collection[i].Item1) >= expiration)
                {
                    collection.RemoveAt(i);
                }
            }
        }
        #region IList Implementation
        public T this[int index]
        {
            get { return collection[index].Item2; }
            set { collection[index] = new Tuple<DateTime, T>(DateTime.Now, value); }
        }
        public IEnumerator<T> GetEnumerator()
        {
            return collection.Select(x => x.Item2).GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return collection.Select(x => x.Item2).GetEnumerator();
        }
        public void Add(T item)
        {
            collection.Add(new Tuple<DateTime, T>(DateTime.Now, item));
        }
        public int Count
        {
            get { return collection.Count; }
        }
        public bool IsSynchronized
        {
            get { return false; }
        }
        public bool IsReadOnly
        {
            get { return false; }
        }
        public void CopyTo(T[] array, int index)
        {
            for (int i = 0; i < collection.Count; i++)
                array[i + index] = collection[i].Item2;
        }
        public bool Remove(T item)
        {
            bool contained = Contains(item);
            for (int i = collection.Count - 1; i >= 0; i--)
            {
                if ((object)collection[i].Item2 == (object)item)
                    collection.RemoveAt(i);
            }
            return contained;
        }
        public void RemoveAt(int i)
        {
            collection.RemoveAt(i);
        }
        public bool Contains(T item)
        {
            for (int i = 0; i < collection.Count; i++)
            {
                if ((object)collection[i].Item2 == (object)item)
                    return true;
            }
            return false;
        }
        public void Insert(int index, T item)
        {
            collection.Insert(index, new Tuple<DateTime, T>(DateTime.Now, item));
        }
        public int IndexOf(T item)
        {
            for (int i = 0; i < collection.Count; i++)
            {
                if ((object)collection[i].Item2 == (object)item)
                    return i;
            }
            return -1;
        }
        public void Clear()
        {
            collection.Clear();
        }
        #endregion
    }
