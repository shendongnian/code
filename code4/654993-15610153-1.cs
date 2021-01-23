    class MyClass
    {
        // Field, direct access to the internal representation
        private int x; 
    
        // Property, access via methods, but syntax like field access
        public int X {
            get { return this.x; } // generates a get-method "int get_X()"
            set { this.x = value; } // generates a set-method "void set_X(int value)"
        }
    }
