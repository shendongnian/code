    /// <summary>
    /// Conversion routines for Google, TMS, and Microsoft Quadtree tile representations, derived from
    /// http://www.maptiler.org/google-maps-coordinates-tile-bounds-projection/ 
    /// </summary>
    public class GlobalMercator
    {
        private const int TileSize = 256;
        private const int EarthRadius = 6378137;
        private const double InitialResolution = 2 * Math.PI * EarthRadius / TileSize;
        private const double OriginShift = 2 * Math.PI * EarthRadius / 2;
        //Converts given lat/lon in WGS84 Datum to XY in Spherical Mercator EPSG:900913
        public static Point LatLonToMeters(double lat, double lon)
        {
            var p = new Point();
            p.X = lon * OriginShift / 180;
            p.Y = Math.Log(Math.Tan((90 + lat) * Math.PI / 360)) / (Math.PI / 180);
            p.Y = p.Y * OriginShift / 180;
            return p;
        }
        //Converts XY point from Spherical Mercator EPSG:900913 to lat/lon in WGS84 Datum
        public static GeoPoint MetersToLatLon(Point m)
        {
            var ll = new GeoPoint();
            ll.Longitude = (m.X / OriginShift) * 180;
            ll.Latitude = (m.Y / OriginShift) * 180;
            ll.Latitude = 180 / Math.PI * (2 * Math.Atan(Math.Exp(ll.Latitude * Math.PI / 180)) - Math.PI / 2);
            return ll;
        }
        //Converts pixel coordinates in given zoom level of pyramid to EPSG:900913
        public static Point PixelsToMeters(Point p, int zoom)
        {
            var res = Resolution(zoom);
            var met = new Point();
            met.X = p.X * res - OriginShift;
            met.Y = p.Y * res - OriginShift;
            return met;
        }
        //Converts EPSG:900913 to pyramid pixel coordinates in given zoom level
        public static Point MetersToPixels(Point m, int zoom)
        {
            var res = Resolution(zoom);
            var pix = new Point();
            pix.X = (m.X + OriginShift) / res;
            pix.Y = (m.Y + OriginShift) / res;
            return pix;
        }
        //Returns a TMS (NOT Google!) tile covering region in given pixel coordinates
        public static Tile PixelsToTile(Point p)
        {
            var t = new Tile();
            t.X = (int)Math.Ceiling(p.X / (double)TileSize) - 1;
            t.Y = (int)Math.Ceiling(p.Y / (double)TileSize) - 1;
            return t;
        }
        public static Point PixelsToRaster(Point p, int zoom)
        {
            var mapSize = TileSize << zoom;
            return new Point(p.X, mapSize - p.Y);
        }
        //Returns tile for given mercator coordinates
        public static Tile MetersToTile(Point m, int zoom)
        {
            var p = MetersToPixels(m, zoom);
            return PixelsToTile(p);
        }
        //Returns bounds of the given tile in EPSG:900913 coordinates
        public static MinMax<Point> TileBounds(Tile t, int zoom)
        {
            var min = PixelsToMeters(new Point(t.X * TileSize, t.Y * TileSize), zoom);
            var max = PixelsToMeters(new Point((t.X + 1) * TileSize, (t.Y + 1) * TileSize), zoom);
            return new MinMax<Point>(min, max);
        }
        //Returns bounds of the given tile in latutude/longitude using WGS84 datum
        public static MinMax<GeoPoint> TileLatLonBounds(Tile t, int zoom)
        {
            var bound = TileBounds(t, zoom);
            var min = MetersToLatLon(bound.Min);
            var max = MetersToLatLon(bound.Max);
            return new MinMax<GeoPoint>(min, max);
        }
        //Resolution (meters/pixel) for given zoom level (measured at Equator)
        public static double Resolution(int zoom)
        {
            return InitialResolution / (Math.Pow(2, zoom));
        }
        public static double ZoomForPixelSize(double pixelSize)
        {
            for (var i = 0; i < 30; i++)
                if (pixelSize > Resolution(i))
                    return i != 0 ? i - 1 : 0;
            throw new InvalidOperationException();
        }
        // Switch to Google Tile representation from TMS
        public static Point ToGoogleTile(Tile t, int zoom)
        {
            return new Point(t.X, ((int)Math.Pow(2, zoom) - 1) - t.Y);
        }
        // Switch to TMS Tile representation from Google
        public static Point ToTmsTile(Tile t, int zoom)
        {
            return new Point(t.X, ((int)Math.Pow(2, zoom) - 1) - t.Y);
        }
        //Converts TMS tile coordinates to Microsoft QuadTree
        public static string QuadTree(int tx, int ty, int zoom)
        {
            var quadtree = "";
            ty = ((1 << zoom) - 1) - ty;
            for (var i = zoom; i >= 1; i--)
            {
                var digit = 0;
                var mask = 1 << (i - 1);
                if ((tx & mask) != 0)
                    digit += 1;
                if ((ty & mask) != 0)
                    digit += 2;
                quadtree += digit;
            }
            return quadtree;
        }
        //Converts a quadtree to tile coordinates
        public static Tile QuadTreeToTile(string quadtree, int zoom)
        {
            int tx= 0, ty = 0;
            for (var i = zoom; i >= 1; i--)
            {
                var ch = quadtree[zoom - i];
                var mask = 1 << (i - 1);
                var digit = ch - '0';
                if ((digit & 1) != 0)
                    tx += mask;
                if ((digit & 2) != 0)
                    ty += mask;
            }
            ty = ((1 << zoom) - 1) - ty;
            return new Tile(tx, ty);
        }
        //Converts a latitude and longitude to quadtree at the specified zoom level 
        public static string LatLonToQuadTree(GeoPoint latLon, int zoom)
        {
            Point m = LatLonToMeters(latLon.Latitude, latLon.Longitude);
            Tile t = MetersToTile(m, zoom);
            return QuadTree(t.X, t.Y, zoom);
        }
        //Converts a quadtree location into a latitude/longitude bounding rectangle
        public static MinMax<GeoPoint> QuadTreeToLatLon(string quadtree)
        {
            int zoom = quadtree.Length;
            Tile t = QuadTreeToTile(quadtree, zoom);
            return TileLatLonBounds(t, zoom);
        }
        //Returns a list of all of the quadtree locations at a given zoom level within a latitude/longude box
        public static List<string> GetQuadTreeList(int zoom, GeoPoint latLonMin, GeoPoint latLonMax)
        {
            if ((latLonMax == null) || (latLonMin == null))
            {
                return null;
            }
            if (latLonMax.Latitude < latLonMin.Latitude || latLonMax.Longitude < latLonMin.Longitude)
                return null;
            Point mMin = LatLonToMeters(latLonMin.Latitude, latLonMin.Longitude);
            Tile tmin = MetersToTile(mMin, zoom);
            Point mMax = LatLonToMeters(latLonMax.Latitude, latLonMax.Longitude);
            Tile tmax = MetersToTile(mMax, zoom);
            var arr = new List<string>();
            for (var ty = tmin.Y; ty <= tmax.Y; ty++)
            {
                for (var tx = tmin.X; tx <= tmax.X; tx++)
                {
                    var quadtree = QuadTree(tx, ty, zoom);
                    arr.Add(quadtree);
                }
            }
            return arr;
        }
    }
    /// <summary>
    /// Holds a LatLon
    /// </summary>
    public class GeoPoint
    {
        public GeoPoint(){}
        public GeoPoint(double lat, double lon)
        {
            Latitude = lat;
            Longitude = lon;
        }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
    /// <summary>
    /// Reference to a Tile X, Y index
    /// </summary>
    public class Tile
    {
        public Tile() { }
        public Tile(int x, int y)
        {
            X = x;
            Y = y;
        }
        public int X { get; set; }
        public int Y { get; set; }
    }
    /// <summary>
    /// Holds Min and Max value pairs 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MinMax<T>
    {
        public MinMax() { }
        public MinMax(T min, T max)
        {
            Min = min;
            Max = max;
        }
        public T Min { get; set; }
        public T Max { get; set; }
    }
