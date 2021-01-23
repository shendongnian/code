    public class MyClass {
       int sizeValue = 0;
       public int Size {
          get {
             return sizeValue;
          }
          set {
             if ( value < 10 ) throw new Exception("Size too small");
             sizeValue = value;
          }
       }
    }
