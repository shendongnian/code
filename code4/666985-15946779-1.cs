    public int CompareTo(object obj)
    {
        if (obj is sortDateTime)
        {
            sortDateTime sDT = (sortDateTime) obj;
            return m_startDate.CompareTo(sDT.m_startDate);
        }
        else
        {
            throw new ArgumentException("object is not a sortDateTime ");   
        }
    }
