    public IEnumerable<Member> GetActiveMembers
    {
        get
        {
            return from activeMember in LeagueMembers
                   where activeMember.IsActive == true
                   select activeMember.Member;
            //return LeagueMembers.Select(a => a.IsActive == true);
        }
    }
