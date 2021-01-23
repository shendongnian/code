    Thread 1                                                          Thread 2
    public Task CallThisOnlyOnce()
    {
      if(_callThisOnlyOnce != null && _callThisOnlyOnce.IsCompleted)
         _callThisOnlyOnce = null;
      if(_callThisOnlyOnce == null)
																	   public Task CallThisOnlyOnce()
																	   {
																	     if(_callThisOnlyOnce != null && _callThisOnlyOnce.IsCompleted)
																	        _callThisOnlyOnce = null;
																	     if(_callThisOnlyOnce == null)
																	        _callThisOnlyOnce = CallThisOnlyOnceAsync();
																	     return _callThisOnlyOnce;
																	   }
         _callThisOnlyOnce = CallThisOnlyOnceAsync();
      return _callThisOnlyOnce;
    }
