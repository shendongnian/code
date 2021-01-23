    public class GenericPath<T> : IEnumerable
        {
            private List<T> items = new List<T>();
    
    
            public List<T> Items
            {
                set { this.items = value; }
                get { return this.items; }
            }
            //some code inc ctrs
    
        }
    
        public class Segment
        {
        }
    
        public class Path : GenericPath<Segment>
        {        
    
        }
    
        public class LinePath : GenericPath<Path>
        {
        }
