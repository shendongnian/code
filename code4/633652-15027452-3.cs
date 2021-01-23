        public Item<T> FirstItem = null;
        public Item<T> CurrentItem = null;
        public TestEnumerator()
        {
        }
        public T Current
        {
            get { return CurrentItem.Value; }
        }
        public void Dispose()
        {
           
        }
        object System.Collections.IEnumerator.Current
        {
            get { throw new NotImplementedException(); }
        }
        public bool MoveNext()
        {
            Program.Counter++;
            if (CurrentItem == null)
            {
                CurrentItem = FirstItem;
                return true;
            }
            if (CurrentItem != null && CurrentItem.NextItem != null)
            {
                CurrentItem = CurrentItem.NextItem;
                return true;
            }
            return false;
        }
        public void Reset()
        {
            CurrentItem = null;
        }
        internal void Add(T p)
        {
            if (FirstItem == null)
            {
                FirstItem = new Item<T>(p);
                return;
            }
            Item<T> lastItem = FirstItem;
            while (lastItem.NextItem != null)
            {
                lastItem = lastItem.NextItem;
            }
            lastItem.NextItem = new Item<T>(p);
        }
    }
