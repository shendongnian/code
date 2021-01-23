    public class ViewModel : INotifyPropertyChanged
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
        private ObservableCollection<Item> items;
        public ObservableCollection<Item> Items
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
        public ViewModel()
        {
            this.InitItems(20);
        }
        public void InitItems(int count)
        {
            this.Items = new ObservableCollection<Item>();
            for (int i = 0; i < count; i++)
                this.Items.Add(new Item() { MyProperty = "Element" + i });
        }
    }
    public class Item
    {
        public string MyProperty { get; set; }
        public override string ToString()
        {
            return this.MyProperty;
        }
    }
