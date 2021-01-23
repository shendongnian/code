    public class GeoLocation
    {
        public GeoLocation(GeoLocation obj) {/* implement a copy constructor */}
        public GeoLocation() {/* default constructor */}
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string LocationName { get; set; }
    }
    public class GeoLocationEx : GeoLocation
    {
        public string Address { get; set; }
    }
    public abstract class Base
    {
        public abstract GeoLocation GeoLocation { get; set; }
    }
    public class Concrete2 : Base
    {
        private GeoLocationEx _geoLocation;
        public override GeoLocation GeoLocation
        {
            get { return _geoLocation; }
            set
            {
                _geoLocation = new GeoLocationEx(value);
            }
        }
    }
