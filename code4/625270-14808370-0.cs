    public class Exceptions : Exception
    {
       Exceptions(string message)
           : base(message) {}
    }
    public class ProccessIsNotStarted : Exceptions
    {
        ProccessIsNotStarted()
            : base()
        {
        }
        ProccessIsNotStarted(string message) 
            : base(message)
        {
            // This will work, because Exceptions defines a constructor accepting a string.
        }
        ProccessIsNotStarted(string message, Exception e)
            : base(message, e) 
        {
            // This will not work, because Exceptions does not define a constructor with (string, Exception).
        }
    }
