    public class TestException : Exception
    {
     /// <summary>
     /// Constructs the exception from a string message
     /// </summary>
     /// <param name="message">error description</param>
     public TestException(String message)
     : base(message)
     {
       base.HResult = -1001;
     }
    }
