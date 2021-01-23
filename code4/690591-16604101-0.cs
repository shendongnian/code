    private Timer m_RequestTimer;
    public void Begin()
    {
                // Timer check
                if (m_RequestTimer != null)
                {
                    m_RequestTimer.Change(Timeout.Infinite, Timeout.Infinite);
                    m_RequestTimer.Dispose();
                    m_RequestTimer = null;
                }
    m_RequestTimer = new System.Threading.Timer(obj => { c.Start(); }, null, 250, System.Threading.Timeout.Infinite);
            }
    }
