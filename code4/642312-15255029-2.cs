    public class SelectableListItemViewModel: ListItemViewModel
    {
        private ObservableCollection<ListItemViewModel> _itemsSource;
        public ObservableCollection<ListItemViewModel> ItemsSource
        {
            get { return _itemsSource ?? (_itemsSource = new ObservableCollection<ListItemViewModel>()); }
        }
        private ListItemViewModel _selectedItem;
        public ListItemViewModel SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                NotifyPropertyChange(() => SelectedItem);
            }
        }
    }
