    public class MessageWrapper
    {
        private int pendingB = EMPTY;
        private const int EMPTY = -1;
        public Message WrapA(int a, int millisecondsTimeout)
        {
            int? b;
            int count = 0;
            while ((b = Interlocked.Exchange(ref pendingB, EMPTY)) == EMPTY)
            {
                if (count % 7 == 0)
                {
                    Thread.Sleep(0);
                }
                else if (count % 23 == 0)
                {
                    Thread.Sleep(1);
                }
                else
                {
                    Thread.Yield();
                }
                if (++count == 480)
                {
                    return new Message(a, null);
                }
            }
            return new Message(a, b);
        }
        public Message WrapB(int b, int millisecondsTimeout)
        {
            int count = 0;
            while (Interlocked.CompareExchange(ref pendingB, b, EMPTY) != EMPTY)
            {
                // Spin
                Thread.SpinWait((4 << count++));
                if (count > 10)
                {
                    // We didn't manage to place our payload.
                    // Let's send it ourselves:
                    return new Message(null, b);
                }
            }
            
            // We placed our payload. 
            // Wait some more to see if some WrapA snatches it.
            while (Interlocked.CompareExchange(ref pendingB, EMPTY, EMPTY) == b)
            {
                Thread.SpinWait((4 << count++));
                if (count > 20)
                {
                    // No WrapA came along. Pity, we will have to send it ourselves
                    int payload = Interlocked.CompareExchange(ref pendingB, EMPTY, b);
                    return payload == b ? new Message(null, b) : null;
                }
            }
            return null;
        }
    }
