    public class FixedSizeCollection<T> : Collection<T>
    {
        protected bool _initializing;
        public int Size { get; private set; }
        public FixedSizeCollection(int size)
        {
            Size = size;
            Init();
        }
        public FixedSizeCollection(int size, IList<T> list) 
        {
            Size = size;
            Init();
            if (list.Count != Size)
                throw new InvalidOperationException("Changing size is not supported.");
            foreach (T item in list)
                Items[list.IndexOf(item)] = item;
        }
        protected virtual void Init()
        {
            _initializing = true;
            base.ClearItems();
            for (int j = 0; j < Size; j++)
                Add(default(T));
            _initializing = false;
        }
        protected override void ClearItems()
        {
            Init();
        }
        protected override void InsertItem(int index, T item)
        {
            if (!_initializing)
                throw new InvalidOperationException("Changing size is not supported.");
            base.InsertItem(index, item);
        }
        protected override void RemoveItem(int index)
        {
            if (!_initializing)
                throw new InvalidOperationException("Changing size is not supported.");
            base.RemoveItem(index);
        }
        protected override void SetItem(int index, T item)
        {
            base.SetItem(index, item);
        }
    }
    public class SquareArray<T> : FixedSizeCollection<FixedSizeCollection<T>>
    {
        public SquareArray(int size) : base(size)
        {
        }
        protected override void Init()
        {
            _initializing = true;
            for (int i = 0; i< Size; i++)
            {
                FixedSizeCollection<T> row = new FixedSizeCollection<T>(Size);
                Add(row);
            }
            _initializing = false;
        }
        protected override void SetItem(int index, FixedSizeCollection<T> item)
        {
            if (item.Count != Size)
                throw new InvalidOperationException("Changing size is not supported.");
            base.SetItem(index, item);
        }
    }
