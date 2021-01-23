	try                        
	{
	//Do something that can throw WebException ? 
	}
	catch (WebException e)
	{
	if (e.Status == (WebExceptionStatus.Success) ||
	    e.Status == (WebExceptionStatus.ConnectFailure) ||
	    e.Status == (WebExceptionStatus.RequestCanceled) ||
	    e.Status == (WebExceptionStatus.Pending) ||
	    e.Status == (WebExceptionStatus.UnknownError) ||
	    e.Status == (WebExceptionStatus.MessageLengthLimitExceeded))
	    Debug.WriteLine("Ok");
	else
	    Debug.WriteLine("Its another WebException");                          
	}
  
