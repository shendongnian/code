    public class DelegateTask : IMonitorableTask {
        private Action<Action<TData>> taskDelegate;
    
        public event EventHandler<TData> TaskProgress;
    
        public DelegateTask(Action<Action<TData>> taskDelegate) {
            if (taskDelegate == null)
                throw new ArgumentNullException("taskDelegate");
    
            this.taskDelegate = taskDelegate;
        }
    
        protected void FireTaskProgress(TData data) {
            var handler = TaskProgress;
    
            if (handler != null)
                handler(this, data);
        }
    
        public void Start() {
            taskDelegate(FireTaskProgress);
        }
    }
