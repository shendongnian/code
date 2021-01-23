    public IEnumerable<Member> GetActiveMembers
    {
        get
        {
            return LeagueMembers.Select(a => a.IsActive == true);
        }
    }
