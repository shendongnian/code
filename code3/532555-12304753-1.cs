        public class B
        {
            // Constructor
            public B(A A) { this.A = A; }
            // Class A as a read-only property
            public A A { get; private set; }
            // Other properties of class B
            public double? BA { get; set; }
        }
