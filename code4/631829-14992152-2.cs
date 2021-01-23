    class EnumerableNode : IEnumerable<int>
    {
        private Node _first;
        public EnumerableNode(Node first) {
            _first = first;
        }
        public IEnumerator<int> GetEnumerator() {
            return new NodeEnumerator(_first);
        }
        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
