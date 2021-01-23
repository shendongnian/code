    static object logAndQueueLock = new object();
    public static void EnqueueRuleTrigger(Rule rule) 
    { 
        lock(logAndQueueLock)
        {
          MyConcurrentQueue._Queue.Enqueue(rule); 
          Log.Message("Enqueued:"+ rule.ToString());
        } 
    } 
    public static Rule DequeueRuleTrigger() 
    { 
        lock(logAndQueueLock)
        {
          Rule rule = null;
          if (MyConcurrentQueue._Queue.Enqueue(out rule)){ 
             Log.Message("Enqueued:"+ rule.ToString());
          }
          return rule; 
        } 
    } 
