    public class MyEventWaitHandler : EventWaitHandle
    {
        public MyEventWaitHandler(bool initialState, EventResetMode mode, string name):base(initialState,mode,name)
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
    public class Example
    {
        private static MyEventWaitHandler _eventHandle1 = new MyEventWaitHandler(false, EventResetMode.AutoReset, "Mode1");
        private static MyEventWaitHandler _eventHandle2 = new MyEventWaitHandler(false, EventResetMode.AutoReset, "Mode1");
       
        public void Main()
        {
            Thread[] threads = new Thread[10];
            for (int i = 0; i < threads.Length; i++)
            {
                threads[i] = new Thread(Method);
                threads[i].Start();
                string name = _eventHandle.WaitNew();
                if (name == "Mode1")
                {
                    //Execute case for first process
                }
                else if (name == "Mode2")
                {
                    //Execute case for second process
                }
            }
        }
        static void Method()
        {
            _eventHandle1.Set();
            _eventHandle2.Set();
        }
    }
