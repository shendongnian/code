    public class pinger
    {
        private Uri m_theUri;
        private Thread m_pingThread;
        private ManualResetEvent m_pingThreadShouldStop;
        private volatile bool m_lastPingResult = false;
        public Pinger(Uri theUri)
        {
            m_theUri = theUri;
        }
        public void Start()
        {
            if (m_pingThread == null)
            {
                m_pingThreadShouldStop = new ManualResetEvent(false);
                m_pingThread = new Thread(new ParameterizedThreadStart(DoPing));
                m_pingThread.Start(m_theUri);
            }
        }
        public void Stop()
        {
            if (m_pingThread !=  null)
            {
                m_pingThreadShouldStop.Set();
                m_pingThread.Join();
                m_pingThreadShouldStop.Close();
            }
        }
        
        public void DoPing(object state)
        {
            Uri myUri = state as Uri;
            while (!m_pingThreadShouldStop.WaitOne(50))
            {
                // Get the result for the ping
                ...
     
                // Set the property
                m_lastPingResult = pingResult;
            }
        }
        public bool LastPingResult
        {
            get { return m_lastPingResult; }
        }
    }
