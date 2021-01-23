    public class AzureCommandQueueManager
    {
        public void Enqueue(ICommand itemToQueue)
        {
            if (itemToQueue == null)            
                throw new ArgumentNullException("itemToQueue");
    
            QueueStorage.AddToQueue((dynamic)itemToQueue);
        }
    
        public IQueueStorage QueueStorage { get; set; }
    }
    
    public interface IQueueStorage
    {
        void AddToQueue<T>(T command) where T : class;        
    }
    
    public class TestCommand : ICommand  {}
    
    public interface ICommand {}
