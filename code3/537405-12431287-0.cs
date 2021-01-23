    private static Queue<DateTime> eventQueue = new Queue<DateTime>();
    private static int timeWindowSeconds = 60;
    private static int threshold = 3;
    private static void TestEvent(object src, EventArgs mea) {
        DateTime now = DateTime.UtcNow;
        DateTime tooOld = now.AddSeconds(-timeWindowSeconds);
        // remove old entries
        while((eventQueue.Count > 0) && (eventQueue.Peek() < tooOld)) {
            eventQueue.Dequeue();
        }
        
        // add new entry
        eventQueue.Enqueue(now);
        
        // test for condition
        if (eventQueue.Count >= threshold) {
            eventQueue.Clear();
            DoSomething();           
        }
    }
