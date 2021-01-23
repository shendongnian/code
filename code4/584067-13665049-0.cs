    public List<String> ListVisits()
    {
        List<String> visits = new List<string>();
        visits.AddRange(ListDeiveries());
        visits.AddRange(ListPickups());
        return visits;
    }
