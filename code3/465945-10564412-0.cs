    public class CustomMode : MercatorMode {
        protected static Range<double> validLatitudeRange = new Range<double>(-45.58328975600631, -8.320212289522944);
        protected static Range<double> validLongitudeRange = new Range<double>(110.7421875, 156.533203125);
    
        protected override Range<double> GetZoomRange(Location center) {
            return new Range<double>(3, 3.8);
        }
    
        public override bool ConstrainView(Location center, ref double zoomLevel, ref double heading, ref double pitch) {
            bool isChanged = base.ConstrainView(center, ref zoomLevel, ref heading, ref pitch);
    
            double newLatitude = center.Latitude;
            double newLongitude = center.Longitude;
    
            if(center.Longitude > validLongitudeRange.To) {
                newLongitude = validLongitudeRange.To;
            } else if(center.Longitude < validLongitudeRange.From) {
                newLongitude = validLongitudeRange.From;
            }
    
            if(center.Latitude > validLatitudeRange.To) {
                newLatitude = validLatitudeRange.To;
            } else if(center.Latitude < validLatitudeRange.From) {
                newLatitude = validLatitudeRange.From;
            }
    
            if(newLatitude != center.Latitude || newLongitude != center.Longitude) {
                center.Latitude = newLatitude;
                center.Longitude = newLongitude;
                isChanged = true;
            }
    
            Range<double> range = GetZoomRange(center);
            if(zoomLevel > range.To) {
                zoomLevel = range.To;
                isChanged = true;
            } else if(zoomLevel < range.From) {
                zoomLevel = range.From;
                isChanged = true;
            }
    
            return isChanged;
        }
    }
