    public class Point // a class (obviously)
    {
        private float x; // private field; also the backing
                         // field for the property `X`
    
        public float X // a public property
        {
            get { return x; }  // (public) getter of the property
            set { x = value; } // (public) setter of the property
                               // both are using the backing field
        }
    
        
        public float Y // an auto-implemented property (this one will
        { get; set; }  // create the backing field, the getter and the
                       // automatically, but hide it from accessing it directly)
    
        public Point(float x, float y) // constructor
        {
            this.x = x;
            this.y = y;
        }
    
        public Point()  // a default constructer,
            : this(0,0) // that calls another constructor
        {}
    }
