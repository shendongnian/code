    [ComVisible(true), 
     Guid("D6D3565F-..."), 
     InterfaceType(ComInterfaceType.InterfaceIsIDispatch)] //! must be IDispatch
    public interface IMyEvents
    {
        [DispId(1)] // the dispid is used to correctly map the events
        void SomethingHappened(DateTime timestamp, string message);
    }
    [ComVisible(true)]
    [Guid("E22E64F7-...")]
    [ProgId("...")]
    [ClassInterface(ClassInterfaceType.None)]
    [ComSourceInterfaces(typeof(IMyEvents))] // binding the event interface
    public class MyComServer : IMyComServer  
    {
        // here we declare the delegate for the event
        [ComVisible(false)]
        public delegate void MyEventHandler(DateTime timestamp, string message);
        // and a public event which matches the method in IMyEvents
        // your code will raise this event when needed
        public event MyEventHandler SomethingHappened;
        ... 
    }
