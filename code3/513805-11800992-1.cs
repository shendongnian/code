    public class ErrorCapable {
      public string ErrorMessage { set; get; }
      public int ErrorCode { set; get; }
    
      public static ErrorCapable Oops(Exception exc) {
        // Code for logging error here
        return new ErrorCapable() { ErrorMessage = exc.Message, ErrorCode = exc.ErrorCode };
      }
    }
    public class Bar : ErrorCapable {
      //...
    }
    public class Baz : ErrorCapable {
      //...
    }
