    public class Region : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private bool isChecked;
        private void OnPropertyChaned(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
        public int RegionID { get; set; }
        public string RegionName { get; set; }
        public bool IsChecked
        {
            get { return isChecked; }
            set
            {
                if (isChecked != value)
                {
                    isChecked = value;
                    OnPropertyChaned("IsChecked");
                }
            }
        }
    }
    public class Country : INotifyPropertyChanged
    {
        private readonly Region parentRegion;
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
        public Country(Region parent)
        {
            parentRegion = parent;
            parentRegion.PropertyChanged += ParentChanged;
        }
        private void ParentChanged(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName.Equals("IsChecked"))
            {
                OnPropertyChanged("IsParentChecked");
            }
        }
        public int CountryID { get; set; }
        public string CountryName { get; set; }
        public int RegionID { get { return parentRegion.RegionID; }}
        public bool IsParentChecked
        {
            get { return parentRegion.IsChecked; }
        }
    }
