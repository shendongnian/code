    public sealed class MessageWrapper
    {
        private int pendingB;
        
        public Message WrapA(int a, int millisecondsTimeout)
        {
            int b = Interlocked.Exchange(ref pendingB, -1);
            return new Message(a, b == -1 ? null : b);
        }
        public Message WrapB(int b, int millisecondsTimeout)
        {
            var sw = new SpinWait();
            while (Interlocked.CompareExchange(ref pendingB, b, -1) != -1)
            {
                // Spin
                sw.SpinOnce();
                
                if (sw.NextSpinWillYield)
                {
                    // Let us make progress instead of yielding the processor
                    // (avoid context switch)
                    return new Message(null, b);
                }
            }
            return null;
        }
    }
