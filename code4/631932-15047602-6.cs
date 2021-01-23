        class MessageWrapper
        {
        object gate = new object();
        int EmptyThreadsToRelease = 0;
        Queue<int> queueA = new Queue<int>();
        Queue<int> queueB = new Queue<int>();
        Object queueLock = new Object();
        public Message WrapA(int a, int millisecondsTimeout)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            lock (gate)
            {
                if (queueB.Count > 0)
                {
                    Interlocked.Increment(ref EmptyThreadsToRelease);
                    return new Message(a, queueB.Dequeue());
                }
                else
                {
                    queueA.Enqueue(a);
                }
            }
            return WrapMessage(millisecondsTimeout - (int)sw.ElapsedMilliseconds, 1);
        }
        public Message WrapB(int b, int millisecondsTimeout)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            lock (gate)
            {
                if (queueA.Count > 0)
                {
                    Interlocked.Increment(ref EmptyThreadsToRelease);
                    return new Message(queueA.Dequeue(), b);
                }
                else
                {
                    queueB.Enqueue(b);
                }
            }
            return WrapMessage(millisecondsTimeout - (int)sw.ElapsedMilliseconds, 2);
        }
        private Message WrapMessage(int millisecondsTimeout, int messageType)
        {
            System.Threading.Thread.Sleep(millisecondsTimeout);
            lock (queueLock)
            {
                if (EmptyThreadsToRelease > 0)
                {
                    Interlocked.Decrement(ref EmptyThreadsToRelease);
                    return null;
                }
                if (messageType == 1)
                    return new Message(queueA.Dequeue(), null);
                if (messageType == 2)
                    return new Message(null, queueB.Dequeue());
            }
            return null;
        }
        }
