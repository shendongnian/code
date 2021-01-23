        bool m_isStartSvcEnabled = true;
        void ToggleServiceEnabled()
        {
            m_isStartSvcEnabled = !m_isStartSvcEnabled;
            mnuStartSvc.Visible = m_isStartSvcEnabled;
            lblStartSvc.Visible = !m_isStartSvcEnabled;
            mnuStopSvc.Visible = !m_isStartSvcEnabled;
            lblStopSvc.Visible = m_isStartSvcEnabled;
        }
