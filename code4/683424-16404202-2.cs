    class Coordinates
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
    
    class Location : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
        public string Name { get; set; }
        private Coordinates coordinates = new Coordinates();
        public Coordinates Coordinates 
        {
            get { return coordinates; }
            set
            {
                if (coordinates == value) return;
                coordinates = value;
                NotifyPropertyChanged("Coordinates");
                NotifyPropertyChanged("CoordinateLatitude");
                NotifyPropertyChanged("CoordinateLongitude");
            }
        }
    
        public double CoordinateLatitude
        {
            get { return (this.Coordinates.Latitude); }
            set { this.Coordinates.Latitude = value; }
        }
    
        public double CoordinateLongitude
        {
            get { return (this.Coordinates.Longitude); }
            set { this.Coordinates.Longitude = value; }
        }
    }
