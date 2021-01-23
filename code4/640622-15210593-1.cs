     public class TabbedViewModel: ViewModelBase
        {
            private ObservableCollection<TabViewModel> _items;
            public ObservableCollection<TabViewModel> Items
            {
                get { return _items ?? (_items = new ObservableCollection<TabViewModel>()); }
            }
    
            private ViewModelBase _selectedItem;
            public ViewModelBase SelectedItem
            {
                get { return _selectedItem; }
                set
                {
                    _selectedItem = value;
                    NotifyPropertyChange(() => SelectedItem);
                }
            }
        }
    
        public class TabViewModel: ViewModelBase
        {
            private string _title;
            public string Title
            {
                get { return _title; }
                set
                {
                    _title = value;
                    NotifyPropertyChange(() => Title);
                }
            }
    
            private bool _isEnabled;
            public bool IsEnabled
            {
                get { return _isEnabled; }
                set
                {
                    _isEnabled = value;
                    NotifyPropertyChange(() => IsEnabled);
                }
            }
    
            private bool _isVisible;
            public bool IsVisible
            {
                get { return _isVisible; }
                set
                {
                    _isVisible = value;
                    NotifyPropertyChange(() => IsVisible);
                }
            }
        }
