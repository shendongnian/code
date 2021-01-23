      public class Path<T> : IEnumerable<T>
            where T : Segment // here we define that parameter is Segment or its child
        {
            private List<T> _segments = new List<T>();        
        
            public List<T> Segments
            {
                set { _segments = value; }
                get { return _segments; }
            }
        
            public IEnumerator GetEnumerator()
            {
                throw new NotImplementedException();
            }
        }
        
        public class LinePath<T> : Path<T> 
            where T : LineSegment // parameter is LineSegment or its child
        {
        
            public LinePath(List<T> segments)
            {
                // no error because Path.Segments of type List<LineSegment>
                Segments = segments;
            }
        }
