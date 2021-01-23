    public  class CarsInfo : INotifyPropertyChanged
    {
        public int Year { get; set; }
        public string Description { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        private bool _carIsSelected;
        public bool CarIsSelected 
        {
            get { return _carIsSelected; }
            set { _carIsSelected = value; NotifyPropertyChanged("CarIsSelected"); } 
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
