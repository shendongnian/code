    class MessageWrapper
    {
        public enum QueueState { NoB, NoA, Neither };
        object gate = new object();
        int? pendingB;
        int EmptyThreadsToRelease = 0;
        ConcurrentQueue<int> queueA = new ConcurrentQueue<int>();
        ConcurrentQueue<int> queueB = new ConcurrentQueue<int>();
        Object queueLock = new Object();
        public Message WrapA(int a, int millisecondsTimeout)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            int b;
            lock (gate)
            {
                if (queueB.TryDequeue(out b))
                {
                    Interlocked.Increment(ref EmptyThreadsToRelease);
                    return new Message(a, b);
                }
                else
                {
                    queueA.Enqueue(a);
                }
            }
            return WrapMessage(millisecondsTimeout, sw);
        }
        public Message WrapB(int b, int millisecondsTimeout)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            int a;
            lock (gate)
            {
                if (queueA.TryDequeue(out a))
                {
                    Interlocked.Increment(ref EmptyThreadsToRelease);
                    return new Message(a, b);
                }
                else
                {
                    queueB.Enqueue(b);
                }
            }
            return WrapMessage(millisecondsTimeout, sw);
        }
        private Message WrapMessage(int millisecondsTimeout, Stopwatch sw)
        {
            System.Threading.Thread.Sleep(millisecondsTimeout - (int)sw.ElapsedMilliseconds);
            lock (queueLock)
            {
                if (EmptyThreadsToRelease > 0)
                {
                    Interlocked.Decrement(ref EmptyThreadsToRelease);
                    return null;
                }
                int m;
                if(queueA.TryDequeue(out m))
                {
                    return new Message(m, null);
                }
                if(queueB.TryDequeue(out m))
                {
                    return new Message(null, m);
                }
            }
            return null;
        }
    }
