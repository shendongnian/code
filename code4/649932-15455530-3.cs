    public interface IWorker<out T> where T : IWorkItem
    {
        void Process(IWorkItem workItem);
    }
    public class WorkerA : IWorker<WorkItemA>
    {
        public void Process(IWorkItem item)
        {
        }
    }
    public class WorkerB : IWorker<WorkItemB>
    {
        public void Process(IWorkItem item)
        {
        }
    }
