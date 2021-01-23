    public class dataPoints
    {
        List<dataPoint> Points;
        public dataPoints(string path)
        {
            Points = new List<dataPoint>();
            //here `path` from constructor arguments
            TextReader tr = new StreamReader(path); 
            //...rest part of your code
        }
