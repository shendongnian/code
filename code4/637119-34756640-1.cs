    List<TeamModel.TeamWithMembers> teamMemberList = teamMemberQueryResult.AsEnumerable().Select(item =>
    new TeamModel.TeamWithMembers() {
        TeamId=item.TeamId,
        TeamName=item.TeamName,
        TeamMembers=item.TeamMembers.ToList()
    }).ToList();
