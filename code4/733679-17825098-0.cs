	// Type: System.Net.WebExceptionStatus
	// Assembly: System, Version=4.0.0.0, Culture=neutral, 
	namespace System.Net
	{
	  public enum WebExceptionStatus
	  {
	    Success = 0,
	    ConnectFailure = 2,
	    SendFailure = 4,
	    RequestCanceled = 6,
	    Pending = 13,
	    UnknownError = 16,
	    MessageLengthLimitExceeded = 17,
	  }
	}
----------
     try
    {
    //Do something that can throw WebException ? 
    }
    catch (WebException e)
    {
    if((int)e.Status  == 0)
    Debug.WriteLine("Success"); 
    }
    
    var test = new Class1.Test();
    test.Run();
