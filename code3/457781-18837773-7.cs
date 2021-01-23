    public class BlockingCounter
    {
        private int m_Count;
        private object m_counterLock = new object();
        private bool m_isClosed = false;
        private int m_MaxSize = 0;
        public BlockingCounter(int maxSize = 0)
        {
            if (maxSize < 0)
                throw new ArgumentOutOfRangeException("maxSize");
            m_MaxSize = maxSize;
        }
        public void WaitableIncrement(int timeoutMs = Timeout.Infinite)
        {
            lock (m_counterLock)
            {
                CheckClosed();
                while (m_MaxSize > 0 && m_Count >= m_MaxSize)
                {
                    Monitor.Wait(m_counterLock, timeoutMs);
                }
                m_Count++;
                if (m_Count == 1)
                {
                    Monitor.PulseAll(m_counterLock);
                }
            }
        }
        public void WaitableDecrement(int timeoutMs = Timeout.Infinite)
        {
            lock (m_counterLock)
            {
                while (m_Count == 0)
                {
                    CheckClosed();
                    Monitor.Wait(m_counterLock, timeoutMs);
                }
               
                m_Count--;
                if (m_MaxSize == 0 || m_Count == m_MaxSize - 1)
                    Monitor.PulseAll(m_counterLock);
                
            }
        }
        void CheckClosed()
        {
            if (m_isClosed)
                throw new Exception("The counter is closed");// <-- throw any custom exception here if needed
        }
        public void Close()
        {
            lock (m_counterLock)
            {
                m_isClosed = true;
                Monitor.PulseAll(m_counterLock);
            }
        }
    }
