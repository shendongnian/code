    class MyClass: IMyInterface {
        // "const" makes it constant, not the name
        public const int CONSTANT = 42;
        
        // static member variable - somewhat like Ruby's @@variable
        private static int classVariable;
        public static int ExposedClassVariable; // but use properties  
        // @variable - unlike Ruby, can be accessed outside "self" scope
        int instanceVariable;
        public int ExposedInstanceVariable;     // but use properties
        
        void method (int parameter) {
          int localVariable;
        }
    }
