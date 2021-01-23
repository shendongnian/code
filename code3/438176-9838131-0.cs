    public IEnumerable<UploadState> GetStates
    {
        get
        {
            foreach (var state in m_states) { 
                yield return state; 
            }
        }
    }
