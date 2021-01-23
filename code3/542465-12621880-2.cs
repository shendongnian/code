    public static class EventLoop
    {
        private class EventTask
        {
            public EventTask(Delegate taskHandler) : this(taskHandler, null) {}
            public EventTask(Delegate taskHandler, Delegate callback)
            {
                TaskHandler = taskHandler;
                Callback = callback;
            }
            private Delegate Callback {get; set;}
            private Delegate TaskHandler {get; set;}
            public void Invoke(object param)
            {
                object[] paramArr = null;
                if (param.GetType().Equals(typeof(object[])))
                {
                    paramArr = (object[]) param; //So that DynamicInvoke does not complain
                }
                
                object res = null;
                if (TaskHandler != null)
                {
                    if (paramArr != null)
                    {
                        res = TaskHandler.DynamicInvoke(paramArr);
                    }
                    else
                    {
                        res = TaskHandler.DynamicInvoke(param);
                    }
                }
                if (Callback != null)
                {
                    EnqueueSyncTask(Callback, res);
                }
            }
        }
        private static WindowsFormsSynchronizationContext _syncContext;
        public static void Run(Action<string[]> mainProc, string[] args)
        {
            //You need to reference System.Windows.Forms
            _syncContext = new WindowsFormsSynchronizationContext();
            EnqueueSyncTask(mainProc, args);
            Application.Run();
        }
        public static void EnqueueSyncTask(Delegate taskHandler, object param)
        {
            _syncContext.Post(new EventTask(taskHandler).Invoke, param);
        }
        public static void EnqueueAsyncTask(Delegate taskHandler, object param, Delegate callback)
        {
            _syncContext.Post(obj => ThreadPool.QueueUserWorkItem(
                new EventTask(taskHandler, callback).Invoke, obj), param);
            Application.DoEvents(); //Start executing the task asap
        }
    }
