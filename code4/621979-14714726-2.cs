    public class Point : IEnumerable
    {
        double[] points = new double[2];
    
        public double X 
        {
            get { return points[0]; }
            set { points[0] = value; }
        }
  
      public double Y
        {
            get { return points[1]; }
            set { points[1] = value; }
        }
    
        public IEnumerator GetEnumerator()
        {
            foreach (var point in points) 
                yield return point;
        }
    }
    
    Which serializes the Point into a compact JSON array:
    
    new Point { X = 1, Y = 2 }.ToJson() // = [1,2]
