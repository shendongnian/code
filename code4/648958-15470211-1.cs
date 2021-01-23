    public class MainViewModel : ViewModelBase
    {
        #region Declarations
        private ObservableCollection<MyTab> tabs;
        private MyTab selectedTab;
        #endregion
        #region Properties
        /// <summary>
        /// Gets or sets the tabs.
        /// </summary>
        /// <value>The tabs.</value>
        public ObservableCollection<MyTab> Tabs
        {
            get
            {
                return tabs;
            }
            set
            {
                tabs = value;
                NotifyPropertyChanged("Tabs");
            }
        }
        /// <summary>
        /// Gets or sets the selected tab.
        /// </summary>
        /// <value>The selected tab.</value>
        public MyTab SelectedTab
        {
            get
            {
                return selectedTab;
            }
            set
            {
                selectedTab = value;
                NotifyPropertyChanged("SelectedTab");
            }
        }
        #endregion
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="MainViewModel"/> class.
        /// </summary>
        public MainViewModel()
        {
            this.Tabs = new ObservableCollection<MyTab>();
            MyTab tab1 = new MyTab();
            tab1.Header = "tab1";
            tab1.Content = "Tab 1 content";
            ObservableCollection<string> tab1StatusList = new ObservableCollection<string>();
            tab1StatusList.Add("tab1 item1");
            tab1StatusList.Add("tab1 item2");
            tab1StatusList.Add("tab1 item3");
            tab1.StatusList = tab1StatusList;
            tab1.SelectedStatus = tab1StatusList.First();
            this.Tabs.Add(tab1);
            MyTab tab2 = new MyTab();
            tab2.Header = "tab2";
            tab2.Content = "Tab 2 content";
            ObservableCollection<string> tab2StatusList = new ObservableCollection<string>();
            tab2StatusList.Add("tab2 item1");
            tab2StatusList.Add("tab2 item2");
            tab2StatusList.Add("tab2 item3");
            tab2.StatusList = tab2StatusList;
            tab2.SelectedStatus = tab2StatusList.First();
            this.Tabs.Add(tab2);
            this.SelectedTab = tab1;
        }
        #endregion
    }
