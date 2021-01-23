    public class GeoLocation
            {
                public double Longitude { get; set; }
                public double Latitude { get; set; }
                public string LocationName { get; set; }
            }
    
            public class GeoLocationEx : GeoLocation
            {
                public double Address { get; set; }
            }
    
            public abstract class Base<T>
            {
                public abstract T GeoLocation { get; set; }
            }
    
            public class Concrete : Base<GeoLocation>
            {
                public override GeoLocation GeoLocation
                {
                    get;
                    set;
                }
            }
    
            public class Concrete2 : Base<GeoLocationEx>
            {
                public override GeoLocationEx GeoLocation
                {
                    get;
                    set;
                }
            }
