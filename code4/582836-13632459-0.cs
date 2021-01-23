    class MyList<T> : IList<T>
    {
        Dictionary<T, List<int>> _indexMap;
        List<T> _items;
        public int IndexOf(T item)
        {
            List<int> indices;
            if(_indexMap.TryGetValue(item, out indices))
            {
                return indices[0];
            }
            return -1;
        }
        public void Add(T item)
        {
            List<int> indices;
            if(!_indexMap.TryGetValue(item, out indices))
            {
                indices = new List<int>();
                _indexMap[item] = indices;
            }
            indices.Add(_items.Count);
            _items.Add(item);
        }
        // ... Other similar type functions here
    }
