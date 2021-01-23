    public class CompareNode: IQueryNode
    {
        public ObservableCollection<IQueryNode> Children { get; private set; }
        public int OpIndex { get; set; }
        public String OpText{ get{ ... } }
        public String Header { get; set; }
        public String Value { get; set; }
        public bool IsBoolNode { get { return false; } }
        public bool IsSelected { get; set; }
        public CompareNode()
        {
            Children = new ObservableCollection<IQueryNode>();
            IsSelected = false;
        }
    }
