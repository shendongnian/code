	public class Match
	{
		public string Team1 { get; set; }
		public string Team2 { get; set; }
		public Match(string team1, string team2)
		{
			Team1 = team1;
			Team2 = team2;
		}
		public override string ToString()
		{
			return string.Format("{0} vs {1}", Team1, Team2);
		}
	}
	public class Round
	{
		public List<Match> Matches { get; private set; }
		public Round()
		{
			Matches = new List<Match>();
		}
		public override string ToString()
		{
			return String.Join(Environment.NewLine, Matches) + Environment.NewLine;
		}
	}
