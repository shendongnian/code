    public class BoolNode :IQueryNode
    {
        public int OpIndex { get; set; }
        public String OpText { get { ... } }
        public ObservableCollection<IQueryNode> Children { get; private set; }
        public bool IsBoolNode{get{return true;}}
        public bool IsSelected { get; set;}
            
        public BoolNode()
        {
            OpIndex = 0;
            Children = new ObservableCollection<IQueryNode>();
            IsSelected = false;
        }
    }
