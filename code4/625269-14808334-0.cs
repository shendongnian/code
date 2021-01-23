    public class Exceptions : Exception
    {        
        Exceptions(string message) 
          : base(message) { }
        Exceptions(string message, Exception e)
          : base(message, e) { }
    }
