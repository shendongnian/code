	using System;
	/* In your model... */
	public sealed class MatchType
	{
		public string Name { get; internal set; }
		public string Description { get; internal set; }
		public int ID { get; internal set; }
	}
	public sealed class Team
	{
		public string Name { get; set; }
		public MatchType MatchType { get; set; }
		public int? MatchTypeID { get; set; }
		public int ID { get; set; }
	}
	/* In your viewmodel... */
	public sealed class TeamSelection
	{
		// These two should be INotifyPropertyChanged, shortened for this example.
		public MatchType[] MatchTypes { get; private set; }
		public Team[] TeamsA { get; private set; }
		public Team[] TeamsB { get; private set; }
		private Team[] teams = null;
		MatchType matchType = null;
		public MatchType SelectedMatchType {
			get { return matchType; }
			set
			{
				if (value != null)
					matchType = value;
				else if (MatchTypes != null && MatchTypes.Length > 0)
					matchType = MatchTypes[0];
				else
					return;
				PropertyHasChanged(() => SelectedMatchType);
				PopulateTeams();
			}
		}
		Team teamA;
		Team teamB;
		public Team SelectedTeamA 
		{
			get { return teamA; }
			set
			{
				if (teamA.ID == teamB.ID)
					// Alternatively, set a flag and stop execution.
					throw new InvalidOperationException("The same team cannot be selected.");
				teamA = value;
				PopulateTeams();
				PropertyHasChanged(() => SelectedTeamA);
			}
		}
	
		public Team SelectedTeamB 
		{
			get { return teamB; }
			set
			{
				if (teamA.ID == teamB.ID)
					// Alternatively, set a flag and stop execution.
					throw new InvalidOperationException("The same team cannot be selected.");
				teamB = value;
				PopulateTeams();
				PropertyHasChanged(() => SelectedTeamB);
			}
		}
		/// <summary>
		/// This can be done on your model, or what I do is pass it to 
		/// an intermediary class, then that sets the busy status to
		/// a BusyIndicator set as the visual root of the application.
		/// </summary>
		public bool IsBusy { get; private set; }
		public string IsBusyDoingWhat { get; private set; }
		public TeamSelection()
		{
			// Call out to DB for the match types, setting busy status
			var wcf = new WcfService();
			wcf.GetMatchTypes(response => 
			{
				wcf.GetMatchTypesForTeam(MatchType, response2 =>
				{
					teams = response.Value.ToArray();
					MatchTypes = response2.Value.ToArray();
					MatchType = MatchTypes[0];
					PopulateTeams();
				});
			});
		}
		void PopulateTeams()
		{
			if (MatchType == null)
				return;
			var op = teams.Where(t => t.MatchTypeID == MatchType.ID);
			if (SelectedTeamA != null)
				TeamsB = op.Where(t => t.ID != SelectedTeamA.ID).OrderBy(t => t.Name);
			else
				TeamsB = op.OrderBy(t => t.Name);
			if (SelectedTeamB != null)
				TeamsA = op.Where(t => t.ID != SelectedTeamB.ID).OrderBy(t => t.Name);
			else
				TeamsA = op.OrderBy(t => t.Name);
		}
	}
