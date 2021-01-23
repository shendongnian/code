    public History GetPastAbuseData(int Id)
    {
        return (from h in _DB.History
                where h.ApplicantId.Equals(Id)
                select h).SingleOrDefault();
    }
