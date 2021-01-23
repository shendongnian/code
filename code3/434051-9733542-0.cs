    BackgroundWorker bgwLoading = new BackgroundWorker();
    bgwLoading.DoWork += (sndr, evnt) =>
    {
        int count = 6;  
        int sleepInterval = 5000;
        bool success = false;
        for (int i = 0; i < count; i++)
        {
            Application.DoEvents();
            m_keywordList.Clear();
            m_keywordList.Add("HeatCoolModeStatus");
            m_role.ReadValueForKeys(m_keywordList, null, null);
            l_currentValue = (int)m_role.GetValue("HeatCoolModeStatus");
            if (l_currentValue == 16)
            {
                success = true;
                break;
            }    
            System.Threading.Thread.Sleep(sleepInterval);
        }
    };
    bgwLoading.RunWorkerAsync();
