     catch ({System.DivideByZeroException ex )
     {
        Console.WriteLine("Oops. I cannot divide by zero." );
     }
     catch ({System.Exception ex )
     {
        Console.WriteLine(GetExceptionMsgs(ex));
     }
     ...in another class...
    public static string GetExceptionMsgs(Exception ex) {
       if( ex == null ) {
           return "No exception = no details";
       }
       var sb = new StringBuilder();
       while( ex != null ) {
            sb.AppendLine(ex.Message);
            ex = ex.InnerException;
       }
       return sb.ToString()
    }
