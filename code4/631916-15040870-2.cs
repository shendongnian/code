    class MessageWrapper
    {
        object gate = new object();
        int? pendingB;
        public Message WrapA(int a, int millisecondsTimeout)
        {
            int? b;
            lock (gate)
            {
                b = pendingB;
                pendingB = null;
                Thread.Sleep(1); // yield. 1 seems the best value after some testing
            }
            return new Message(a, b);
        }
        public Message WrapB(int b, int millisecondsTimeout)
        {
            int? bb = b;
            lock (gate)
            {
                if (pendingB == null)
                {
                    pendingB = b;
                    bb = null;
                }
            }
            Thread.Sleep(3);
            
            if (bb == null)
            {
                lock (gate)
                {
                    if (pendingB != null)
                    {
                        bb = pendingB;
                        pendingB = null;
                    }
                }
            }
            return new Message(null, bb);
        }
    }
