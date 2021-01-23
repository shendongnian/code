    [JsonObject(MemberSerialization.OptIn)]
    public class Test
    {
        private GeoCoordindate _location;
    
        [JsonProperty(PropertyName = "longitude")]
        public double Longitude{ get; set; }
    
        [JsonProperty(PropertyName = "latitude")]
        public double Latitude { get; set; }
    
        public GeoCoordinate Location
        {
            get
            {
                if (_location == null)
                    _location = new GeoCoordinate(Latitude, Longitude);
        
                return _location;
            }
        }
    }
    
