    public class Traverse<T> : IEnumerable<int>
    {
        T[] _list;
        T _value;
    
        public Traverse(T[] list, T value)
        {
            this._list = list;
            this._value = value; 
        }
    
        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < _list.Length; i++)
                if (_list[i].Equals(_value))
                    yield return i;
        }
    
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
