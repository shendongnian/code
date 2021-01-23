    public class PulseEvent
    {
        public PulseEvent()
        {
            cur = new ManualResetEvent(false);
            alt = new ManualResetEvent(true);
        }
        ManualResetEvent cur, alt;
        public void PulseAll()
        {
            ManualResetEvent tmp;
            if ((tmp = Interlocked.Exchange(ref alt, null)) != null) // try claiming 'pulser'
            {
                tmp.Reset();                     // prepare for re-use, ending previous cycle
                (tmp = Interlocked.Exchange(ref cur, tmp)).Set();    // atomic swap & pulse
                Volatile.Write(ref alt, tmp);    // release claim; re-allow 'pulser' claims
            }
        }
        public bool Wait(int ms) => cur.WaitOne(ms);
        public void Wait() => Wait(Timeout.Infinite);
    };
