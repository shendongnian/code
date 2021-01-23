     public class TabItemDetail
    {
        public string Header { get; set; }
    }
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        #region Members
        List<string> _dataSource = null;
        string _selectedDataSource = null;
        ObservableCollection<TabItemDetail> _tabItems = null;
        #endregion
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
        public ObservableCollection<TabItemDetail> Items
        {
            get
            {
                if (_tabItems == null)
                {
                    _tabItems = GetTabItems();
                }
                return _tabItems;
            }
        }
        public List<string> DataSource
        {
            get
            {
                if (_dataSource == null)
                {
                    _dataSource = GetDataSource();
                }
                return _dataSource;
            }
        }
        public string SelectedDataSource
        {
            get { return _selectedDataSource; }
            set
            {
                if (_selectedDataSource == value)
                    return;
                _selectedDataSource = value;
                AddItemsToTab(value);
                OnPropertyChanged("SelectedDataSource");
            }
        }
        #region Private methods
        private void AddItemsToTab(string selectedItem)
        {
            if (_tabItems != null && _tabItems.Count > 0)
            {
                var query = from item in _tabItems
                            where item.Header == selectedItem
                            select item;
                if (query.Count() == 1)
                    return;
                else
                    _tabItems.Add(new TabItemDetail { Header = selectedItem });
            }
        }
        private List<string> GetDataSource()
        {
            List<string> source = new List<string>();
            source.Add("Default tab");
            source.Add("Voltage Tab");
            return source;
        }
        private ObservableCollection<TabItemDetail> GetTabItems()
        {
            ObservableCollection<TabItemDetail> newSource = new ObservableCollection<TabItemDetail>();
            newSource.Add(new TabItemDetail { Header = "Connect" });
            return newSource;
        }
        #endregion
    }
