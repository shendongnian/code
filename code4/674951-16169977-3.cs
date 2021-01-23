    public sealed class BrowserInstance : IEquatable<BrowserInstance>
    {
    
        // ...
    
        public bool Equals(BrowserInstance other)
        {
            if (ReferenceEquals(null, other))
                return false;
            if (ReferenceEquals(this, other))
                return true;
            if (m_Process == null)
            {
                if (other.m_Process == null)
                    return true;
                return false;
            }
    
            if (other.m_Process == null)
                return false;
    
            return m_Process.Id == other.m_Process.Id && m_Process.MainModule.BaseAddress == other.m_Process.MainModule.BaseAddress;
        }
    
        public override bool Equals(object obj)
        {
            return Equals(obj as BrowserInstance);
        }
    
        public override int GetHashCode()
        {
            unchecked
            {
                return m_Process != null ? ((m_Process.Id.GetHashCode() * 397) ^ m_Process.MainModule.BaseAddress.GetHashCode()) : 0;
            }
        }
    }
