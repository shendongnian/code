    public class SortedTreeViewWindowViewModel: PropertyChangedBase
    {
        private string _newValueString;
        public int? NewValue { get; set; }
        public string NewValueString
        {
            get { return _newValueString; }
            set
            {
                _newValueString = value;
                int integervalue;
                //If the text is a valid numeric value, use that to create a new node.
                if (int.TryParse(value, out integervalue))
                    NewValue = integervalue;
                else
                    NewValue = null;
                OnPropertyChanged("NewValueString");
            }
        }
        public TreeViewModel SelectedItem { get; set; }
        public ObservableCollection<TreeViewModel> Items { get; set; }
        public ICollectionView ItemsView { get; set; }
        public SortedTreeViewWindowViewModel()
        {
            Items = new ObservableCollection<TreeViewModel>();
            ItemsView = new ListCollectionView(Items) {SortDescriptions = { new SortDescription("Value",ListSortDirection.Ascending)}};
        }
        public void AddNewItem()
        {
            ObservableCollection<TreeViewModel> targetcollection;
            //Insert the New Node as a Root node if nothing is selected.
            targetcollection = SelectedItem == null ? Items : SelectedItem.Items;
            if (NewValue != null && !targetcollection.Any(x => x.Value == NewValue))
            {
                targetcollection.Add(new TreeViewModel(NewValue.Value));
                NewValueString = string.Empty;    
            }
            
        }
    }
