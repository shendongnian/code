    public class chartObject
    {
        private chartObject _parent;
        private int? _descCache = null;
        public string name { get; set; }
        public int descendants {
            get {
                return _descCache ?? calcDescendents();
            }
        }
        public List<chartObject> children { get; set; }
        public void AddChild(chartObject child) {
            child._parent = this;
            children.Add(child);
            chartObject tmp = this;
            while (tmp != null) {
                tmp._descCache = null;
                tmp = tmp._parent;
            }
        }
        private int calcDescendents() {
            return children.Count+children.Sum(child => child.descendants);
        }
    }
