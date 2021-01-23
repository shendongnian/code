    public CancellationToken GetCancellationToken(Task t)
    {
        object m_contingentProperties = t.GetType().GetField("m_contingentProperties", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance).GetValue(t);
        object m_cancellationToken = m_contingentProperties.GetType().GetField("m_cancellationToken", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance).GetValue(m_contingentProperties);
        return (CancellationToken)m_cancellationToken;
    }
