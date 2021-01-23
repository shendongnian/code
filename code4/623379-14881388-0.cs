    public class ChunkyList<T> : IList<T>
    {
        public ChunkyList()
        {
            MaxBlockSize = 65536;
        }
    
        public ChunkyList(int maxBlockSize)
        {
            MaxBlockSize = maxBlockSize;
        }
     
        private List<T[]> _blocks = new List<T[]>();
    
        public int Count { get; private set; }
    
        public int MaxBlockSize { get; private set; }
    
        public bool IsReadOnly
        {
            get { throw new NotImplementedException(); }
        }
    
        public IEnumerator<T> GetEnumerator()
        {
            var index = 0;
            foreach (var items in _blocks)
                foreach (var item in items)
                {
                    yield return item;
                    if (Count <= ++index)
                        break;
                }
        }
    
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    
        public void Add(T item)
        {
            var indexInsideBlock = GetIndexInsideBlock(Count);
            if (indexInsideBlock == 0)
                _blocks.Add(new T[1]);
            else
            {
                var lastBlockIndex = _blocks.Count - 1;
                var lastBlock = _blocks[lastBlockIndex];
                if(indexInsideBlock >= lastBlock.Length)
                {
                    var newBlockSize = lastBlock.Length*2;
                    if (newBlockSize >= MaxBlockSize)
                        newBlockSize = MaxBlockSize;
    
                    _blocks[lastBlockIndex] = new T[newBlockSize];
                    Array.Copy(lastBlock, _blocks[lastBlockIndex], lastBlock.Length);
                }
            }
    
            _blocks[GetBlockIndex(Count)][indexInsideBlock] = item;
    
            Count++;
        }
    
        public void AddRange(IEnumerable<T> items)
        {
            foreach (var item in items)
                Add(item);
        }
    
        public void Clear()
        {
            throw new NotImplementedException();
        }
    
        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }
    
        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }
    
        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }
    
        public int IndexOf(T item)
        {
            throw new NotImplementedException();
        }
    
        public void Insert(int index, T item)
        {
            throw new NotImplementedException();
        }
    
        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }
    
        public T this[int index]
        {
            get
            {
                if (index >= Count)
                    throw new ArgumentOutOfRangeException("index");
    
                var blockIndex = GetBlockIndex(index);
                var block = _blocks[blockIndex];
    
                return block[GetIndexInsideBlock(index)];
            }
            set { throw new NotImplementedException(); }
        }
    
        private int GetBlockIndex(int index)
        {
            return index / MaxBlockSize;
        }
    
        private long GetIndexInsideBlock(int index)
        {
            return index % MaxBlockSize;
        }
    }
