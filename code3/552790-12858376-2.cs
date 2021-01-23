    public class YourViewModel
    {
        public ObservableCollection<TreeItem> TreeItems { get; set; }
        public ICommand TreeItemSelectedCommand { get; set; }
        private void TreeItemSelected(TreeItem selectedTreeItem)
        {
        }
        public YourViewModel()
        {
            TreeItemSelectedCommand = new DelegateCommand(TreeItemSelected);
            TreeItems = new ObservableCollection<TreeItem>();
            TreeItems.Add(new TreeItem{Header = "Item A"});
            TreeItems.Add(new TreeItem{Header = "Item B"});
            TreeItems.First().SubItems.Add(new TreeItem{Header = "Item C"}); 
        }
    }
