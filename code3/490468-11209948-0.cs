    public sealed class FibonacciHeap<TKey, TValue>
    {
        readonly List<Node> _root = new List<Node>();
        int _count;
        Node _min;
    
        public void Push(TKey key, TValue value)
        {
            Insert(new Node {
                Key = key,
                Value = value
            });
        }       
    
        public KeyValuePair<TKey, TValue> Peek()
        {
            if (_min == null)
                throw new InvalidOperationException();
            return new KeyValuePair<TKey,TValue>(_min.Key, _min.Value);
        }       
    
        public KeyValuePair<TKey, TValue> Pop()
        {
            if (_min == null)
                throw new InvalidOperationException();
            var min = ExtractMin();
            return new KeyValuePair<TKey,TValue>(min.Key, min.Value);
        }
    
        void Insert(Node node)
        {
            _count++;
            _root.Add(node);
            if (_min == null)
            {
                _min = node;
            }
            else if (Comparer<TKey>.Default.Compare(node.Key, _min.Key) < 0)
            {
                _min = node;
            }
        }
    
        Node ExtractMin()
        {
            var result = _min;
            if (result == null)
                return null;
            foreach (var child in result.Children)
            {
                child.Parent = null;
                _root.Add(child);
            }
            _root.Remove(result);
            if (_root.Count == 0)
            {
                _min = null;
            }
            else
            {
                _min = _root[0];
                Consolidate();
            }
            _count--;
            return result;
        }
    
        void Consolidate()
        {
            var a = new Node[UpperBound()];
            for (int i = 0; i < _root.Count; i++)
            {
                var x = _root[i];
                var d = x.Children.Count;
                while (true)
                {   
                    var y = a[d];
                    if (y == null)
                        break;                  
                    if (Comparer<TKey>.Default.Compare(x.Key, y.Key) > 0)
                    {
                        var t = x;
                        x = y;
                        y = t;
                    }
                    _root.Remove(y);
                    i--;
                    x.AddChild(y);
                    y.Mark = false;
                    a[d] = null;
                    d++;
                }
                a[d] = x;
            }
            _min = null;
            for (int i = 0; i < a.Length; i++)
            {
                var n = a[i];
                if (n == null)
                    continue;
                if (_min == null)
                {
                    _root.Clear();
                    _min = n;
                }
                else
                {
                    if (Comparer<TKey>.Default.Compare(n.Key, _min.Key) < 0)
                    {
                        _min = n;
                    }
                }
                _root.Add(n);
            }
        }
    
        int UpperBound()
        {
            return (int)Math.Floor(Math.Log(_count, (1.0 + Math.Sqrt(5)) / 2.0)) + 1;
        }
    
        class Node
        {
            public TKey Key;
            public TValue Value;
            public Node Parent;
            public List<Node> Children = new List<Node>();
            public bool Mark;
    
            public void AddChild(Node child)
            {
                child.Parent = this;
                Children.Add(child);
            }
    
            public override string ToString()
            {
                return string.Format("({0},{1})", Key, Value);
            }
        }
    }
