    public override int GetHashCode()
    {
        var x= 17;
        x = x * 31 + m_X.GetHashCode();
        x = x * 31 + m_Y.GetHashCode();
        x = x * 31 + m_Z.GetHashCode();
        return x;
    }
