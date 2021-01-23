    class NodeEnumerator : IEnumerator<int>
    {
        private Node _current_node;
        public NodeEnumerator(Node first) {
            _current_node = new Node { Data = 0, Next = first };
        }
        public int Current {
            get { return _current_node.Data; }
        }
        object IEnumerator.Current {
            get { return Current; }
        }
        public bool MoveNext() {
            if (_current_node == null) {
                return false;
            }
            _current_node = _current_node.Next;
            return _current_node != null;
        }
        public void Reset() {
            throw new NotSupportedException();
        }
        public void Dispose() {
        }
    }
