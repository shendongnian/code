    [GuidAttribute("1A585C4D-3371-48dc-AF8A-AFFECC1B0967") ]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
    public interface MyEvents
    {
        void ConnectedEvent(string state);
    }
    [ComSourceInterfaces(typeof(MyEvents))]
    public class MyClass
    {
        public event Action<string> ConnectedEvent;
      
        public MyClass() { }
        public void DoSomething(string state)
        { 
            if (ConnectedEvent != null)
                ConnectedEvent(state);
        }
    }
