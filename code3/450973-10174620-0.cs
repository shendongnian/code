    var respId = SessionData.CurrentSeminar.GetSeminCbaRespId();
    
    public static int GetSeminCbaRespId(this typeofCurrentSeminar CurrentSeminar)
    {
       return CurrentSeminar != null ? CurrentSeminar.SeminCbaRespId : default(int);
    }
