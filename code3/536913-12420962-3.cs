    void OnMyEvent()
    {
      var myEvent = MyEvent;             // Thread A gets _copy_ of invocation list
      if (myEvent != null)               // Using copy, so no problem 
      {                                  // Thread B unsubscribes _last_ handler
        myEvent(this, EventArgs.Empty);  // Still using copy, so no problem 
      }
    }
