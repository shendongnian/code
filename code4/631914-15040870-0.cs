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
            lock (gate)
            {
                if (pendingB == null)
                {
                    pendingB = b;
                    return null;
                }
            }
            return new Message(null, b);
        }
    }
