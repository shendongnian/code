    var pollTimer = new Timer( HandlePoll, null, 0, Timeout.Infinite );
    ...
    void HandlePoll( object state )
    {
      DoPoll();
      pollTimer.Change( pollInterval, Timeout.Infinite );
    }
