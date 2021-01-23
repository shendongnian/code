    public bool HasInfo
    { 
        [System.Security.SecurityCritical]  // auto-generated
        get
        {
            bool fInfo = false; 
            // Set the flag to true if there is either remoting data, or 
            // security data or user data 
            if(
                (m_RemotingData != null &&  m_RemotingData.HasInfo) || 
                (m_SecurityData != null &&  m_SecurityData.HasInfo) ||
                (m_HostContext != null) ||
                HasUserData
              ) 
            {
                fInfo = true; 
            } 
            return fInfo; 
        }
    }
