    void Main()
    {
        var counters = new Counters();
        counters.DoneCounter += 34;
        var val = counters.DoneCounter;
        val.Dump(); // 34
    }
    
    public class Counters
    {
        int doneCounter = 0;
        public int DoneCounter
        {
            get { return Interlocked.CompareExchange(ref doneCounter, 0, 0); }
            set { Interlocked.Exchange(ref doneCounter, value); }
        }
    }
