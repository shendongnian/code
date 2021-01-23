    public class CircularQueue
    {
      private int totalItems;
      private Queue<object> queue = new Queue<object>();
    
      public CircularQueue(int maxCount)
      {
        this.totalItems = maxCount;
      }
    
      /// <summary>
      /// Get first object from queue.
      /// </summary>
      public object Dequeue()
      {
        // ToDo: You might want to check first if the queue is empty to avoid a InvalidOperationException
        object firstObject = this.queue.Dequeue();
        return firstObject;
      }
    
      public void EnQueue(object objectToPutIntoQueue)
      {
        if (this.queue.Count >= this.totalItems)
        {
          object unusedObject = this.queue.Dequeue();
    
          // ToDo: Cleanup the instance of ununsedObject.
        }
    
        this.queue.Enqueue(objectToPutIntoQueue);
      }
    }
