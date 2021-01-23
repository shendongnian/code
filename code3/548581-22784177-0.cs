    public static class PointUtils
    {
        public const double MercatorGoogleHeight = 256;
        public const double MercatorGoogleWidth = 256;
        public const double PixelLongintudeOrigin = MercatorGoogleWidth / 2;
        public const double PixelLatitudeOrigin = MercatorGoogleHeight / 2;
        public const double PixelsPerLongintudeDegre = MercatorGoogleWidth / 360;
        public const double RadsPerLatitudeDegre = MercatorGoogleHeight / (2 * Math.PI);
    }
    /// <summary>
    /// Point Pixel on Mercator Google Zoom 0
    /// </summary>
    public class PointPixel
    {
        public double X { get; set; }
        public double Y { get; set; }
        public PointCoordinates ToPointCoordinates()
        {
            var lng = (X - PointUtils.PixelLongintudeOrigin) / PointUtils.PixelsPerLongintudeDegre;
            var latRad = (Y - PointUtils.PixelLatitudeOrigin)/-PointUtils.RadsPerLatitudeDegre;
            var lat = (2*Math.Atan(Math.Exp(latRad)) - Math.PI/2).RadToDeg();
            return new PointCoordinates()
                {
                    Latitude = lat,
                    Longitude = lng
                };
        }
    }
    /// <summary>
    /// Point on Map World
    /// </summary>
    public class PointCoordinates
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public PointPixel ToPointPixel()
        {
            var x = PointUtils.PixelLongintudeOrigin + PointUtils.PixelsPerLongintudeDegre * Longitude;
            var siny = Math.Sin(Latitude.DegToRad());
            var y = PointUtils.PixelLatitudeOrigin - (Math.Log((1 + siny) / (1 - siny)) / 2) * PointUtils.RadsPerLatitudeDegre;
            return new PointPixel() { X = x, Y = y };
            
        }
    }
