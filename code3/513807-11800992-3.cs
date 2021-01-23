    public class ErrorCapable {
      public string ErrorMessage { set; get; }
      public int ErrorCode { set; get; }
    
      public static ErrorCapable<T> Oops(Exception exc) where T : ErrorCapable, new() {
        // Code for logging error here
        return new T() { ErrorMessage = exc.Message, ErrorCode = exc.ErrorCode };
      }
    }
    public class Bar : ErrorCapable {
      //...
    }
    public class Baz : ErrorCapable {
      //...
    }
