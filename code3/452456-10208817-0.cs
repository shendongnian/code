    // in main code:
    var locker = mySerialManager.Enquee(command);
    lock (locker)
    {
         // this will only be executed, when mySerialManager unlocks the lock
    }
    // in SerialManager
    public object Enqueue(object command)
    {
        var locker = HowToCreateALockedObject();
        EnqueueCommand(command, locker);
        return locker;
    }
