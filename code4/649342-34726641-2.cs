    public CancellationToken GetCancellationToken(Task task)
    {
        object m_contingentProperties = task
            .GetType()
            .GetField("m_contingentProperties",
                BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
            .GetValue(task);
    
        object m_cancellationToken = m_contingentProperties
            .GetType()
            .GetField("m_cancellationToken",
                BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
            .GetValue(m_contingentProperties);
    
        return (CancellationToken)m_cancellationToken;
    }
