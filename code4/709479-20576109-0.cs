    public class TeaFilePointList : IPointList
    {
        TeaFile<point> tf;
    
        private int _maxPts = -1;
        private int _minBoundIndex = -1;
        private int _maxBoundIndex = -1;
    
        struct point
        {
            public TeaTime.Time x;
            public double y;
        }
    
        public TeaFilePointList(DateTime[] x, double[] y)
        {
            tf = TeaFile<point>.Create(Path.GetRandomFileName() + ".tea");
            for (var i = 0; i < x.Length; i++)
                tf.Write(new point() { x = x[i], y = y[i] });
        }
    
        public void SetBounds(double min, double max, int maxPts)
        {
            _maxPts = maxPts;
    
            // find the index of the start and end of the bounded range
    
            var xmin = (DateTime)new XDate(min);
            var xmax = (DateTime)new XDate(max);
    
            int first = tf.BinarySearch(xmin, item => (DateTime)item.x);
            int last = tf.BinarySearch(xmax, item => (DateTime)item.x);
    
            // Make sure the bounded indices are legitimate
            // if BinarySearch() doesn't find the value, it returns the bitwise
            // complement of the index of the 1st element larger than the sought value
            
            if (first < 0)
            {
                if (first == -1)
                    first = 0;
                else
                    first = ~(first + 1);
            }
    
            if (last < 0)
                last = ~last;
    
            _minBoundIndex = first;
            _maxBoundIndex = last;
        }
    
        public int Count
        {
            get
            {
                int arraySize = (int)tf.Count;
    
                // Is the filter active?
                if (_minBoundIndex >= 0 && _maxBoundIndex >= 0 && _maxPts > 0)
                {
                    // get the number of points within the filter bounds
                    int boundSize = _maxBoundIndex - _minBoundIndex + 1;
    
                    // limit the point count to the filter bounds
                    if (boundSize < arraySize)
                        arraySize = boundSize;
    
                    // limit the point count to the declared max points
                    if (arraySize > _maxPts)
                        arraySize = _maxPts;
                }
    
                return arraySize;
            }
        }
    
        public PointPair this[int index]
        {
            get
            {
                if (_minBoundIndex >= 0 && _maxBoundIndex >= 0 && _maxPts >= 0)
                {
                    // get number of points in bounded range
                    int nPts = _maxBoundIndex - _minBoundIndex + 1;
    
                    if (nPts > _maxPts)
                    {
                        // if we're skipping points, then calculate the new index
                        index = _minBoundIndex + (int)((double)index * (double)nPts / (double)_maxPts);
                    }
                    else
                    {
                        // otherwise, index is just offset by the start of the bounded range
                        index += _minBoundIndex;
                    }
                }
    
                double xVal, yVal;
                if (index >= 0 && index < tf.Count)
                    xVal = new XDate(tf.Items[index].x);
                else
                    xVal = PointPair.Missing;
    
                if (index >= 0 && index < tf.Count)
                    yVal = tf.Items[index].y;
                else
                    yVal = PointPair.Missing;
    
                return new PointPair(xVal, yVal, PointPair.Missing, null);
            }
        }
    
        public object Clone()
        {
            throw new NotImplementedException(); // I'm lazy...
        }
    
        public void Close()
        {
            tf.Close();
            tf.Dispose();
            File.Delete(tf.Name);
        }
    }
