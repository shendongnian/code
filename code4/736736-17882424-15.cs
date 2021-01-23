    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string header = txtRemove.Text; //name of Treeviewitem to delete
            TreeView view = trvView; //get from location
    
            RemoveAll(view.Items, p => string.Equals(p.Header, header));
        }
    
        public bool Remove(ItemCollection items, Predicate<TreeViewItem> isValid)
        {
            for (int i = items.Count - 1; i >= 0; i--)
            {
                TreeViewItem vItem = (TreeViewItem)items[i];
                if (isValid(vItem))
                {
                    items.RemoveAt(i);
                    return true;
                }
                else
                {
                    bool isDeleted = Remove(vItem.Items, isValid);
                    if (isDeleted)
                        return isDeleted;
                }
            }
            return false;
        }
    
        public void RemoveAll(ItemCollection items, Predicate<TreeViewItem> isValid)
        {
            for (int i = items.Count - 1; i >= 0; i--)
            {
                TreeViewItem vItem = (TreeViewItem)items[i];
                if (isValid(vItem))
                {
                    items.RemoveAt(i);
                }
                else
                {
                    RemoveAll(vItem.Items, isValid);
                }
            }
        }
    
    }
 
