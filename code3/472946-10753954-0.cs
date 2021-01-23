    public class StartStopTask
    {
        private readonly Action _action;
        public StartStopTask(Action action)
        {
            _action = action;
        }
 
        public void Start()
        {           
            _task = new Task(_action);
            _task.Start();
        }
        ...
    }
