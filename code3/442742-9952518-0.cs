    class Type1<T, U> {
      public static Type1<T, U> New(U p) {
        return NewCore(p);
      }
    
      public static Type1<T, U> New(T p) {
        return NewCore(p);
      }
    
      private static Type1<T, U> New(object o) {  
        ...
      }
    }
