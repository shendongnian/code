    public class BlockingCounter : IDisposable
    {
        private int m_Count;
        private object m_counterLock = new object();
        private bool m_isClosed = false;
        private volatile bool m_isDisposed = false;
        private int m_MaxSize = 0;
        private ManualResetEvent m_Finished = new ManualResetEvent(false);
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
                while (m_MaxSize > 0 && m_Count >= m_MaxSize)
                {
                    CheckClosedOrDisposed();
                    if (!Monitor.Wait(m_counterLock, timeoutMs))
                        throw new TimeoutException("Failed to wait for counter to decrement.");
                }
                CheckClosedOrDisposed();
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
                try
                {
                    while (m_Count == 0)
                    {
                        CheckClosedOrDisposed();
                        if (!Monitor.Wait(m_counterLock, timeoutMs))
                            throw new TimeoutException("Failed to wait for counter to increment.");
                    }
                    CheckDisposed();
                    m_Count--;
                    if (m_MaxSize == 0 || m_Count == m_MaxSize - 1)
                        Monitor.PulseAll(m_counterLock);
                }
                finally
                {
                    if (m_isClosed && m_Count == 0)
                        m_Finished.Set();
                }
            }
        }
        void CheckClosedOrDisposed()
        {
            if (m_isClosed)
                throw new Exception("The counter is closed");
            CheckDisposed();
        }
        void CheckDisposed()
        {
            if (m_isDisposed)
                throw new ObjectDisposedException("The counter has been disposed.");
        }
        public void Close()
        {
            lock (m_counterLock)
            {
                CheckDisposed();
                m_isClosed = true;
                Monitor.PulseAll(m_counterLock);
            }
        }
        public bool WaitForFinish(int timeoutMs = Timeout.Infinite)
        {
            CheckDisposed();
            lock (m_counterLock)
            { 
                 if (m_Count == 0)
                     return true;
            }
            return m_Finished.WaitOne(timeoutMs);
        }
        public void CloseAndWait (int timeoutMs = Timeout.Infinite)
        {
            Close();
            WaitForFinish(timeoutMs);
        }
        public void Dispose()
        {
            if (!m_isDisposed)
            {
                m_isDisposed = true;
                lock (m_counterLock)
                {
                    // Wake up all waiting threads, so that they know the object 
                    // is disposed and there's nothing to wait anymore
                    Monitor.PulseAll(m_counterLock);
                }
                m_Finished.Close();
            }
        }
    }
