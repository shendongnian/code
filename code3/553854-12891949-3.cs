	public static List<Round> ComputeFixtures(List<string> listTeam)
	{
		var result = new List<Round>();
		var numberOfRounds = (listTeam.Count - 1);
		var numberOfMatchesInARound = listTeam.Count / 2;
		var teams = new List<string>();
		teams.AddRange(listTeam.Skip(numberOfMatchesInARound).Take(numberOfMatchesInARound));
		teams.AddRange(listTeam.Skip(1).Take(numberOfMatchesInARound - 1).ToArray().Reverse());
		var numberOfTeams = teams.Count;
		for (var roundNumber = 0; roundNumber < numberOfRounds; roundNumber++)
		{
			var round = new Round();
			var teamIdx = roundNumber % numberOfTeams;
			round.Matches.Add(new Match(teams[teamIdx], listTeam[0]));
			for (var idx = 1; idx < numberOfMatchesInARound; idx++)
			{
				var firstTeamIndex = (roundNumber + idx) % numberOfTeams;
				var secondTeamIndex = (roundNumber + numberOfTeams - idx) % numberOfTeams;
				round.Matches.Add(new Match(teams[firstTeamIndex], teams[secondTeamIndex]));
			}
			result.Add(round);
		}
		return result;
	}
