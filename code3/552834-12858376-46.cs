    public class MyViewModel : INotifyPropertyChanged
    {
        private TreeItem _selectedItem;
        public ObservableCollection<TreeItem> TreeItems { get; set; }
        public TreeItem SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                //This will be called when an item is selected in the TreeView.
                //If you set it from code it will also change selection in the TreeView
                if(_selectedItem == value)
                    return;
                _selectedItem = value;
                OnPropertyChanged("SelectedItem");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
        public MyViewModel()
        {
            TreeItems = new ObservableCollection<TreeItem>();
            TreeItems.Add(new TreeItem{Header = "Tree Item A"});
            TreeItems.Add(new TreeItem{Header = "Tree Item B"});
            TreeItems.First().SubItems.Add(new TreeItem{Header = "Tree Item C"}); 
        }
    }
