    public class MyTask : ITaskWrapper
    {
        public void TaskMethod()
        {
            Task.Factory.StartNew(() => DoSomeWork());
        }
    }
