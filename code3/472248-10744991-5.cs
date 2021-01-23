    public class MyTabViewModel : INotifyPropertyChanged
    {
        public MyTabViewModel()
        {
            Items =
                new List<MyTabItem>
                    {
                        new MyTabItem
                            {
                                Title = "Overview",
                                Content = new UserControl1()
                            },
                        new MyTabItem
                            {
                                Title = "Detail",
                                Content = new UserControl2()
                            },
                        new MyTabItem
                            {
                                Title = "Reviews",
                                Content = new UserControl3()
                            },
                    };
        }
        public IEnumerable<MyTabItem> Items { get; private set; }
        private MyTabItem _selectedItem;
        public MyTabItem SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SelectedItem"));
            }
        }
        #region Implementation of INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
    }
    public class MyTabItem
    {
        public string Title { get; set; }
        public UserControl Content { get; set; }
    }
