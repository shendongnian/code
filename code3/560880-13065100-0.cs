    public virtual void DebugFormat(string format, params object[] args)
    {
        if (this.IsDebugEnabled)
        {
           this.Logger.Log(declaringType, m_levelDebug, String.Format(format, args));
        }
    }
