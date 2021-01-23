    public class ClassHandler
    {
        public delegate void DoProcesses();
        public event DoProcesses DoProcessesEvent;
        public void OnDoProcessEvent()
        {
            if (DoProcessesEvent != null)
                DoProcessesEvent();
        }
    }
