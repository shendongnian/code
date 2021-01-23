    public int CompareTo(object obj)
    {
        sortDateTime sDT = null;
        if(obj is sortDateTime)
            sDT = (sortDateTime) obj; //here ERROR
        
        if(sDT != null)
        {
            return m_stDate.CompareTo(sDT.m_stDate);
        }
        else
        {
            throw new ArgumentException("object is not a sortDateTime type.");
        }
    }
