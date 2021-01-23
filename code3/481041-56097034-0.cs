    using System.Collections.Generic;
    using System.Linq;
    
    public class TwoWayDictionary<T1, T2>
    {
        Dictionary<T1, T2> _Forwards = new Dictionary<T1, T2>();
        Dictionary<T2, T1> _Backwards = new Dictionary<T2, T1>();
        
        public IReadOnlyDictionary<T1, T2> Forwards => _Forwards;
        public IReadOnlyDictionary<T2, T1> Backwards => _Backwards;
        
        public IEnumerable<T1> Set1 => Forwards.Keys;
        public IEnumerable<T2> Set2 => Backwards.Keys;
        
        
        public TwoWayDictionary()
        {
            _Forwards = new Dictionary<T1, T2>();
            _Backwards = new Dictionary<T2, T1>();
        }
        
        public TwoWayDictionary(int capacity)
        {
            _Forwards = new Dictionary<T1, T2>(capacity);
            _Backwards = new Dictionary<T2, T1>(capacity);
        }
        
        public TwoWayDictionary(Dictionary<T1, T2> initial)
        {
            _Forwards = initial;
            _Backwards = initial.ToDictionary(kvp => kvp.Value, kvp => kvp.Key);
        }
        
        public TwoWayDictionary(Dictionary<T2, T1> initial)
        {
            _Backwards = initial;
            _Forwards = initial.ToDictionary(kvp => kvp.Value, kvp => kvp.Key);
        }
        
        
        public T1 this[T2 index]
        {
            get => _Backwards[index];
            set
            {
                if (_Backwards.TryGetValue(index, out var removeThis))
                    _Forwards.Remove(removeThis);
        
                _Backwards[index] = value;
                _Forwards[value] = index;
            }
        }
        
        public T2 this[T1 index]
        {
            get => _Forwards[index];
            set
            {
                if (_Forwards.TryGetValue(index, out var removeThis))
                    _Backwards.Remove(removeThis);
        
                _Forwards[index] = value;
                _Backwards[value] = index;
            }
        }
        
        public int Count => _Forwards.Count;
        
        public bool Contains(T1 item) => _Forwards.ContainsKey(item);
        public bool Contains(T2 item) => _Backwards.ContainsKey(item);
        
        public bool Remove(T1 item)
        {
            if (!this.Contains(item))
                return false;
        
            var t2 = _Forwards[item];
        
            _Backwards.Remove(t2);
            _Forwards.Remove(item);
        
            return true;
        }
        
        public bool Remove(T2 item)
        {
            if (!this.Contains(item))
                return false;
        
            var t1 = _Backwards[item];
        
            _Forwards.Remove(t1);
            _Backwards.Remove(item);
        
            return true;
        }
        
        public void Clear()
        {
            _Forwards.Clear();
            _Backwards.Clear();
        }
    }
