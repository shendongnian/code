    public static EventWaitHandle GetActivationEvent()
    {
    	EventWaitHandle sync = new EventWaitHandle(false, EventResetMode.ManualReset, Constants.ActivationEventName);
    	return sync;
    }
