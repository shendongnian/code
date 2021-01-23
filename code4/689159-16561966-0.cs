    public class BackgroundOperation
    {
        private readonly SynchronizationContext m_synchronizationContext;
    
        public BackgroundOperation()
        {
            m_synchronizationContext = SynchronizationContext.Current;
        }
    
        …
    
        public void ReportProgress(int progression)
        {
            Progression = progression;
    
            var handler = OnProgressChanged;
            if (handler != null)
                m_synchronizationContext.Post(
                    _ => handler(
                        this,
                        new ProgressChangedEventArgs { Progression = progression }),
                    null);
        }
    }
