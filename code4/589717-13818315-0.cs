    namespace WpfApplication1
    {
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
    
                TreeNode root = new TreeNode();
                root.Header = "root";
                
                tree1.Items.Clear();
                // add node to tree before adding handlers, or you'll get
                // a StackOverflowException
                tree1.Items.Add(root);
    
                root.AddHandler(TreeNode.ExpandedEvent, new RoutedEventHandler(expandedHandler));
    
            }
    
            private void expandedHandler(object sender, RoutedEventArgs e) { newNodeCopyExpandedHandlers(sender as TreeNode); }
    
            private void newNodeCopyExpandedHandlers(TreeNode node)
            {
                TreeNode newNode = new TreeNode();
                newNode.Header = "nuovo!";
    
                // add node to tree before adding handlers, or you'll get
                // a StackOverflowException
                tree1.Items.Add(newNode);
    
                foreach (Delegate d in newNode.GetHandlers(node, TreeNode.ExpandedEvent))
                    newNode.AddHandler(TreeNode.ExpandedEvent, d);
            }
        }
    
        public class TreeNode : TreeViewItem
        {
            private Dictionary<RoutedEvent, List<Delegate>> handlersList = new Dictionary<RoutedEvent, List<Delegate>>();
    
            public new void AddHandler(RoutedEvent e, Delegate d)
            {
                if (!handlersList.ContainsKey(e)) handlersList.Add(e, new List<Delegate>());
                handlersList[e].Add(d);
    
                base.AddHandler(e, d);
            }
            public new void RemoveHandler(RoutedEvent e, Delegate d)
            {
                if (!handlersList.ContainsKey(e)) handlersList.Add(e, new List<Delegate>());
                if (handlersList[e].Contains(d)) handlersList[e].Remove(d);
    
                base.RemoveHandler(e, d);
            }
    
            public List<Delegate> GetHandlers(TreeNode n, RoutedEvent e)
            {
                if (n.handlersList.ContainsKey(e)) return n.handlersList[e];
                else return null;
            }
        }
    }
