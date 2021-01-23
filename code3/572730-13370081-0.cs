    public class ViewModel
    {
       private List<Node> _rootNodes;
       public List<Node> RootNodes 
       {
         get
         {
           return _rootNodes;
         }
         set
         {
           _rootNodes = value;
           NotifyPropertyChange(() => RootNodes);
         }
       }
    
       public ViewModel()
       {
          RootNodes = new List<Node>{new Node(){Text = "This is a Root Node}", 
                                     new Node(){Text = "This is the Second Root Node"}};
       }
