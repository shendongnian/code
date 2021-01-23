    public string GetPastAbuseData(int Id)
    {
    
        var query = (from h in _DB.History
              where h.ApplicantId.Equals(Id)
              select h.AbuseComment).FirstOrDefault();
        return query == null ? string.empty : query;
     }
