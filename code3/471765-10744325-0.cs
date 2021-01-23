    public class ReaderWriterLockSlimExtended : ReaderWriterLockSlim
    {
        private Thread m_currentOwnerThread = null;
        private object m_syncRoot = new object();
        public Thread CurrentOwnerThread
        {
            get
            {
                lock (m_syncRoot)
                {
                    return m_currentOwnerThread;
                }
            }
        }
        public Thread CurrentOwnerThreadUnsafe
        {
            get
            {
                return m_currentOwnerThread;
            }
        }
        public new void EnterWriteLock()
        {
            lock (m_syncRoot)
            {
                base.EnterWriteLock();
                m_currentOwnerThread = Thread.CurrentThread;
            }
            Debug.WriteLine("Enter Write Lock - Current Thread : {0} ({1})", CurrentOwnerThread.Name, CurrentOwnerThread.ManagedThreadId);
        }
        public new void ExitWriteLock()
        {
            Debug.WriteLine("Exit Write Lock - Current Thread : {0} ({1})", CurrentOwnerThread.Name, CurrentOwnerThread.ManagedThreadId);
            lock (m_syncRoot)
            {
                m_currentOwnerThread = null; //Must be null before exit!
                base.ExitWriteLock();
            }
        }  
    }
