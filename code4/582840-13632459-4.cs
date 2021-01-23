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
        // Attempt at a Remove implementation, this could probably be improved
        // but here is my first crack at it
        public bool Remove(T item)
        {
            List<int> indices;
            if(!_indexMap.TryGetValue(item, out indices))
            {
                // Not found so can just return false
                return false;
            }
            int index = indices[0];
            indices.RemoveAt(0);
            if (indices.Count == 0)
            {
                _indexMap.Remove(item);
            }
            for(int i=index+1; i < _items.Count; ++i)
            {
                List<int> otherIndexList = _indexMap[_items[i]];
                for(int j=0; j < otherIndexList.Count; ++j)
                {
                    int temp = otherIndexList[j];
                    if (temp > index)
                    {
                        otherIndexList[j] = --temp;
                    }
                }
            }
            return _items.RemoveAt(index);
        }
        // ... Other similar type functions here
    }
