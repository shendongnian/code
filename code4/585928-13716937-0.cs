    public abstract class BaseProcessing<TV, TW> : IProcessing
        where TV : TaskRequest
        where TW : TaskResponse
    {
        protected abstract TW DoProcess(TV req);
        public TaskResponse Process(TaskRequest req)
        {
            return DoProcess((TV)req);
        }
    }
