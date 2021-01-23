    //Client application environments
    public class WindowsApplication
    {
        public void ExecuteWindowsService()
        {
            var ws = new WindowsService();
            var _eventHandle = new MyEventWaitHandler(false, EventResetMode.AutoReset, "WindowsApplicationMode");
            ws.Execute(_eventHandle);
            _eventHandle.Set();
        }
      
    }
    public class WebApplication
    {
        public void ExecuteWebService()
        {
            var ws = new WindowsService();
            var _eventHandle = new MyEventWaitHandler(false, EventResetMode.AutoReset, "WebApplicationMode");
            ws.Execute(_eventHandle);
            _eventHandle.Set();
        }
    }
    //Windows Service Environment
    public class MyEventWaitHandler : EventWaitHandle
    {
        public MyEventWaitHandler(bool initialState, EventResetMode mode, string name)
            : base(initialState, mode, name)
        {
            this.EventHandlerName = name;
        }
        //it should not be set to empty string from external
        public string EventHandlerName;
        public string WaitNew()
        {
            if (base.WaitOne())
                return EventHandlerName;
            else return String.Empty;
        }
    }
    public class WindowsService
    {
        public void Execute(MyEventWaitHandler _eventHandle)
        {
            Thread[] threads = new Thread[10];
            for (int i = 0; i < threads.Length; i++)
            {
                threads[i] = new Thread(Method);
                threads[i].Start();
                string name = _eventHandle.WaitNew();
                if (name == "WindowsApplicationMode")
                {
                    //Execute case for first process
                }
                else if (name == "WebApplicationMode")
                {
                    //Execute case for second process
                }
            }
        }
        static void Method()
        {
            //Some Task
        }
    }
