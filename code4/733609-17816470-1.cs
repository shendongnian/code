    public class TabsViewModel: NotificationObject
    {
        public TabsViewModel()
        {
            Tabs = new[]
                {
                    new TabViewModel("TAB1", "Data 1 Tab 1", "Data 2 Tab1"), 
                    new TabViewModel("TAB2", "Data 1 Tab 2", "Data 2 Tab2"), 
                };
        }
        private TabViewModel _selectedTab;
        public TabViewModel SelectedTab
        {
            get { return _selectedTab; }
            set
            {
                if (Equals(value, _selectedTab)) return;
                _selectedTab = value;
                RaisePropertyChanged(() => SelectedTab);
            }
        }
        public IEnumerable<TabViewModel> Tabs { get; set; } 
    }
    public class TabViewModel
    {
        public TabViewModel(string tabName, params string[] data)
        {
            TabName = tabName;
            TabData = data.Select(d => new RowData(){Property1 = d}).ToArray();
        }
        public string TabName { get; set; }
        public RowData[] TabData { get; set; }
    }
    public class RowData
    {
        public string Property1 { get; set; }
    }
