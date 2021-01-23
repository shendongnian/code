    public class YourViewModel
    {
        public ObservableCollection<TreeItem> TreeItems { get; set; }
        public ICommand TreeItemSelectedCommand { get; set; }
        private void TreeItemSelected(TreeItem selectedTreeItem)
        {
            //This method will be called when a TreeViewItem is selected
        }
        public YourViewModel()
        {
            TreeItemSelectedCommand = new DelegateCommand<TreeItem>(TreeItemSelected);
            TreeItems = new ObservableCollection<TreeItem>();
            TreeItems.Add(new TreeItem{Header = "Item A"});
            TreeItems.Add(new TreeItem{Header = "Item B"});
            TreeItems.First().SubItems.Add(new TreeItem{Header = "Item C"}); 
        }
    }
