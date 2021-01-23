    static object logAndQueueLock = new object();
    public static void EnqueueRuleTrigger(Rule rule) 
    { 
        lock(logAndQueueLock)
        {
          MyConcurrentQueue._Queue.Enqueue(rule); 
          Log.Message("Enqueued:"+ rule.ToString());
        } 
    } 
