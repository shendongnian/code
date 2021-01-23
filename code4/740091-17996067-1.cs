    public interface IQueryNode
    {
        ObservableCollection<IQueryNode> Children { get; }
        
        int OpIndex { get; set; }
        
        String OpText{get;}
        bool IsBoolNode { get; }
        bool IsSelected { get; set; }
    }
