    public interface IQueueManager<out T, out Q> where T : IQueueMessage<Q>
                                                 where Q : IQueueItem
    {
    }
    public class QueueManager<T, Q> : IQueueManager<T, Q>
        where T : IQueueMessage<Q>
        where Q : IQueueItem
    {
    }
