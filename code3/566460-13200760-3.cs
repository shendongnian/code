    public string GetPastAbuseData(int Id)
    {
      return (from h in _DB.History
              where h.ApplicantId.Equals(Id)
              select h.AbuseComment).FirstOrDefault();
    }
