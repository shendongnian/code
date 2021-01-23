    public class MainWindowModel
    {
        public MainWindowModel(MainWindowTreeViewModel treeView)
        {
            TreeView = treeView;
        }
        public MainWindowTreeViewModel TreeView { get; private set; }
    }
    public class MainWindowTreeViewModel
    {
        public MainWindowTreeViewModel(params MainWindowTreeViewNodeModel[] nodes)
        {
            Nodes = nodes.ToList().AsReadOnly();
        }
        public ReadOnlyCollection<MainWindowTreeViewNodeModel> Nodes { get; private set; }
    }
    public class MainWindowTreeViewNodeModel
    {
        public MainWindowTreeViewNodeModel(string text, params MainWindowTreeViewNodeModel[] nodes)
        {
            Text = text;
            Nodes = nodes.ToList().AsReadOnly();
        }
        public string Text { get; private set; }
        public ReadOnlyCollection<MainWindowTreeViewNodeModel> Nodes { get; private set; }
        public bool IsLeaf { get { return Nodes.Count == 0; } }
    }
