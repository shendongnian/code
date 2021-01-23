      public class Path<T> : IEnumerable<T>
            where T : Segment
        {
            private List<T> _segments = new List<T>();
        
        
            public List<T> Segments
            {
                set { _segments = value; }
                get { return _segments; }
            }
        
            public IEnumerator<T> GetEnumerator()
            {
                throw new NotImplementedException();
            }
        }
        
        public class LinePath<T> : Path<T>
            where T : LineSegment
        {
        
            public LinePath(List<T> segments)
            {
                Segments = segments;
            }
        }
