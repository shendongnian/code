    public class MainViewModel: INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
        #region Items (INotifyPropertyChanged Property)
        private ObservableCollection<ItemViewModel> items;
        public ObservableCollection<ItemViewModel> Items
        {
            get { return this.items; }
            set
            {
                if (this.items != value)
                {
                    this.items = value;
                    this.OnPropertyChanged("Items");
                }
            }
        }
        #endregion
        public MainViewModel()
        {
            this.Items = new ObservableCollection<ItemViewModel>();
            for (int i = 0; i < 10; i++)
                this.Items.Add(new ItemViewModel() { MyProperty = "Item" + i });
        }
    }
