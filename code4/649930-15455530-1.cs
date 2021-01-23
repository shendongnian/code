    public class WorkerRepository
    {
        private readonly Dictionary<Type, IWorker<IWorkItem>> _registeredWorkers =
            new Dictionary<Type, IWorker<IWorkItem>>();
        public void RegisterWorker(IWorker<IWorkItem> worker)
        {
            var type = (from iface in worker.GetType().GetInterfaces()
                          where iface.IsGenericType
                          where iface.GetGenericTypeDefinition() == typeof(IWorker<>)
                          select iface.GetGenericArguments()[0]).First();
            if (!_registeredWorkers.ContainsKey(type))
            {
                _registeredWorkers[type] = worker;
            }
        }
        // You don't need this method, just added it to check if I indeed retrieved the correct type
        //
        public IWorker<IWorkItem> RetrieveWorkerForWorkItem(IWorkItem item)
        {
            var type = item.GetType();
            var registeredWorker = _registeredWorkers[type];
            return registeredWorker;
        }
        public void ProcessWorkItem(IWorkItem item)
        {
            var type = item.GetType();
            var registeredWorker = _registeredWorkers[type];
            registeredWorker.Process(item);
        }
    }
