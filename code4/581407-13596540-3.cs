    class DataPoint
    {
        // Option 1: Field + read only property
        private string _latitude;
        public string Latitude { get { return _latitude; } }
    
        // Option 2: Property + compiler generated field
        public string Longitude { get; private set; }
        public string Elevation { get; private set; }
    
        // Constructor
        public DataPoint(string latitude, string longtitude, string elevation)
        {
            // Internally in this class we use fields
            _latitude = latitude;
            // Unless we use property option 2
            this.Longitude = longitude;
            this.Elevation = elevation; 
        }
    }     
