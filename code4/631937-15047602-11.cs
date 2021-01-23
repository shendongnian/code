        class MessageWrapper
        {
        object gate = new object();
        int EmptyThreadsToReleaseA = 0;
        int EmptyThreadsToReleaseB = 0;
        Queue<int> queueA = new Queue<int>();
        Queue<int> queueB = new Queue<int>();
        AutoResetEvent EmptyThreadEventA = new AutoResetEvent(false);
        AutoResetEvent EmptyThreadEventB = new AutoResetEvent(false);
        public Message WrapA(int a, int millisecondsTimeout)
        {
            lock (gate)
            {
                if (queueB.Count > 0)
                {
                    Interlocked.Increment(ref EmptyThreadsToReleaseB);
                    EmptyThreadEventB.Set();
                    return new Message(a, queueB.Dequeue());
                }
                else
                {
                    queueA.Enqueue(a);
                }
            }
            System.Threading.Thread.Sleep(millisecondsTimeout);
            //EmptyThreadEventA.WaitOne(millisecondsTimeout);
            lock (gate)
            {
                if (EmptyThreadsToReleaseA > 0)
                {
                    Interlocked.Decrement(ref EmptyThreadsToReleaseA);
                    return null;
                }
                return new Message(queueA.Dequeue(), null);
            }
        }
        public Message WrapB(int b, int millisecondsTimeout)
        {
            lock (gate)
            {
                if (queueA.Count > 0)
                {
                    Interlocked.Increment(ref EmptyThreadsToReleaseA);
                    EmptyThreadEventA.Set();
                    return new Message(queueA.Dequeue(), b);
                }
                else
                {
                    queueB.Enqueue(b);
                }
            }
            System.Threading.Thread.Sleep(millisecondsTimeout);
            //EmptyThreadEventB.WaitOne(millisecondsTimeout);
            lock (gate)
            {
                if (EmptyThreadsToReleaseB > 0)
                {
                    Interlocked.Decrement(ref EmptyThreadsToReleaseB);
                    return null;
                }
                return new Message(null, queueB.Dequeue());
            }
        }
        }
