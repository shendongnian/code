	public class Match
	{
		public Match( string Home, string Away )
		{
			HomeTeam = Home;
			HomeGoals = 0;
			AwayTeam = Away;
			AwayGoals = 0;
		}
		// simple properties with PROTECTED setters, yet readable by anyone
		public string HomeTeam
		{ get; protected set; }
		public int HomeGoals
		{ get; protected set; }
		public string AwayTeam
		{ get; protected set; }
		public int AwayGoals
		{ get; protected set; }
		// just place-holder since I don't know rest of your declarations
		public EventHandler goal;
	
		public void PlayMatch()
		{
			for (int i = 0; i < 6; i++)
			{
				if (i % 2 == 0) 
					HomeGoals++;
				else 
					AwayGoals++;
                                
				// Report to anyone listening that a score was made...
				if (goal != null) 
				    goal(this, null);
				Thread.Sleep(1000);
			} 
		}
	}
	// Now, the background worker
	public class MatchBGW : BackgroundWorker
	{
		// each background worker preserves the "Match" instance it is responsible for.
		// this so "ReportProgress" can make IT available for getting values.
		public Match callingMatch
		{ get; protected set; }
		// require parameter of the match responsible for handling activity
		public MatchBGW(Match m)
		{
			// preserve the match started by the background worker activity
			callingMatch = m;
			// tell background worker what method to call
			// using lambda expression to cover required delegate parameters 
			// and just call your function ignoring them.
			DoWork += (sender, e) => m.PlayMatch();
			// identify we can report progress	
			WorkerReportsProgress = true;
			// Attach to the match.  When a goal is scored, notify ME (background worker)
			m.goal += GoalScored;
		}
		// this is called from the Match.
		public void GoalScored(object sender, EventArgs e)
		{
			// Now, tell this background worker to notify whoever called IT
			// that something changed.  Can be any percent, just something to
			// trigger whoever called this background worker, so reported percent is 1
			ReportProgress(1);
		}
	}
