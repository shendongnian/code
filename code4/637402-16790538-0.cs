    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class MultiLookup<Key, Value> : ILookup<Key, Value>
    {
        Dictionary<Key, HashSet<Value>> Contents = new Dictionary<Key, HashSet<Value>>();
        public void Add(Key key, Value value)
        {
            if (!Contains(key))
            {
                Contents[key]=new HashSet<Value>();
            }
            Contents[key].Add(value);
        }
        public void Add(IEnumerable<Tuple<Key, Value>> items)
        {
            foreach (var item in items)
            {
                Add(item.Item1, item.Item2);
            }
        }
        public void Remove(Key key, Value value)
        {
            if (!Contains(key))
            {
                return;
            }
            Contents[key].Remove(value);
            if (Contents[key].Count==0)
            {
                Contents.Remove(key);
            }
        }
        public void RemoveKey(Key key)
        {
            Contents.Remove(key);
        }
        public IEnumerable<Key> Keys
        {
            get
            {
                return Contents.Keys;
            }
        }
        public int Count
        {
            get
            {
                return Contents.Count;
            }
        }
        public bool Contains(Key key)
        {
            return Contents.ContainsKey(key);
        }
        private class Grouping : IGrouping<Key, Value>
        {
            public MultiLookup<Key, Value> _source;
            public Key _key;
            public Key Key
            {
                get { return _key; }
            }
            public static HashSet<Value> Empty = new HashSet<Value>();
            public IEnumerator<Value> GetEnumerator()
            {
                if (!_source.Contains(_key))
                {
                    yield break;
                }
                else
                {
                    foreach (var item in _source[_key])
                    {
                        yield return item;
                    }
                }
            }
            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                return this.GetEnumerator();
            }
        }
        public IEnumerator<IGrouping<Key, Value>> GetEnumerator()
        {
            return (from p in Contents
                   select new Grouping() { _key = p.Key, _source = this }).GetEnumerator();
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        public IEnumerable<Value> this[Key key]
        {
            get { return Contents[key]; }
        }
    }
