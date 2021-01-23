    // in main code:
    var locker = mySerialManager.Enquee(command);
    lock (locker)
    {
         // this will only be executed, when mySerialManager unlocks the lock
    }
    // in SerialManager
    public object Enqueue(object command)
    {
        var locker = new Object();
        Monitor.Enter(locker); 
        // NOTE: Monitor.Exit() gets called when command result 
        // arrives on serial port
        EnqueueCommand(command, locker);
        return locker;
    }
