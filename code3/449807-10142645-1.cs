    public SwimmingEvent(String EvName, String EvDate, String EvTime, String EvFee, String EvVenue, String Distance, String InOrOut)
    :   base (EvName, EvTime, EvFee, EvVenue, Distance) {
        m_distance = Distance;
        m_inOutVar = InOrOut;
    }
