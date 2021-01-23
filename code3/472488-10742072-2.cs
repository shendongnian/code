    namespace System { 
      class Object { 
        private Object() { } 
      }
    }
    
    namespace Example3 {
      // This will properly fail to compile since it can't bind to the private
      // Object constructor.  This demonstrates that we are using our definition
      // of Object instead of mscorlib's 
      class C : object { } // Uses our System.Object
    }
