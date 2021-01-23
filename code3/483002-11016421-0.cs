    [Conditional("DEBUG")]
    public void WriteLine(string message)
    {
        if (m_Logger != null) m_Logger.WriteLine(message);
    }
