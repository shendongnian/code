    [Serializable]
    public class Marks
    {
        public List<latlon> marks = new List<latlon>();
    }
    public class latlon
    {
        public double[] c;
        public int[] xy;
        public string tooltip;
        public attributes attrs;
        public latlon (double lat, double lon)
        {
            c = new double[] { lat, lon };
        }
        public latlon (int x, int y)
        {
            xy = new int[] { x, y };
        }
    }
    public class attributes
    {
        public string href;
        public string src;
    }
