    public enum ActivityState
    {
        Sending,
        Receiving,
        Idle
    }
    public interface IDataTransferManager
    {
        // This event will fire when the activity state changes.
        // note that Action<T> is introduced in .NET 3.5
        // if you're using .NET 2.0, you can use a delegate.
        event Action<ActivityState> DataActivityStateChange;
       
        void Send(byte[] data);
        //byte[] Receive(); 
        // ... more methods ... //
    }
