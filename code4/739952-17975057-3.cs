    namespace TreeViewExample
    {
        using System.Collections.ObjectModel;
        using System.Windows.Controls;
    
        class MainWindowViewModel
        {
            public ObservableCollection<TreeViewItem> Tree { get; set; }
    
            public MainWindowViewModel()
            {
                Tree = new ObservableCollection<TreeViewItem>();
                Tree.Add(GetLoadedTreeRoot());
            }
    
            private TreeViewItem GetLoadedTreeRoot()
            {
                TreeViewItem parent = new TreeViewItem() { Header = "Parent" };
                TreeViewItem child1 = new TreeViewItem() { Header = "Child 1" };
                TreeViewItem child2 = new TreeViewItem() { Header = "Child 2" };
                TreeViewItem grandchild1 = new TreeViewItem() { Header = "Grandchild 1" };
                TreeViewItem grandchild2 = new TreeViewItem() { Header = "Grandchild 2" };
    
                child1.Items.Add(grandchild1);
                child2.Items.Add(grandchild2);
                parent.Items.Add(child1);
                parent.Items.Add(child2);
                return parent;
            }
        }
    }
