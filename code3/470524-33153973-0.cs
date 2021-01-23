    private volatile bool _insideFirstChanceExceptionHandler;    
            
    // ...
        
    AppDomain.CurrentDomain.FirstChanceException += OnFirstChanceException;
        
    // ...
            
    private void OnFirstChanceException(object sender, FirstChanceExceptionEventArgs args)
	{
		if (_insideFirstChanceExceptionHandler)
		{
			// Prevent recursion if an exception is thrown inside this method
			return;
		}
		_insideFirstChanceExceptionHandler = true;
		try
		{
			// Code which may throw an exception
		}
		catch
		{
			// You have to catch all exceptions inside this method
		}
		finally
		{
			_insideFirstChanceExceptionHandler = false;
		}
	}
