    public class DispatcherGroup
    {
        private List<Action> _delegates;
        private List<object[]> _parameters;
        private ManualResetEvent _isFinished;
    
        public void Add(Action toInvoke, params object[] parameters)
        {
            _delegates.Add(toInvoke);
            _parameters.Add(parameters);
        }
    
        public void Invoke(Dispatcher dispatcher)
        {
            List<DispatcherOperation> operations = new List<>();
            for(int i = 0; i < _delegates.Length; i++)
            {
                DispatcherOperation operation = dispatcher.BeginInvoke(_delegates[i], _parameters[i]);
                operations.Add(operation);
            }
    
            // check status of all operations before completion
        }
    
    }
    
    public class DispatcherGroupInvoker
    {
        private Queue<DispatcherGroup> _groups;
        public Dispatcher Dispatcher { get;set;}
        public void Invoke()
        {
            while (!_groups.Count != 0)
            {
                DispatcherGroup group = _groups.Dequeue();
                group.Invoke(Dispatcher);
            }
        } 
    }
