    public class MapValues
    {
        public string Latitude { get; set; }
        public string Longitude{ get; set; }
        public string City{ get; set; }
        public string Address{ get; set; }
        public string ZipCode{ get; set; }
        public string State{ get; set; }
        public MapValues(string latitude, string longitude, string city, string address, string zipCode, string state)
        {
            this.Latitude = latitude;
            this.Longitude= longitude;
            this.City= city;
            this.Address= address;
            this.ZipCode= zipCode;
            this.State= state;
        }
    }
