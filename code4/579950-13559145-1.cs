		private void button1_Click(object sender, RoutedEventArgs e)
		{
			// create your "Matches" between teams
			matches = new List<Match>();
			matches.Add(new Match("A", "B"));
			matches.Add(new Match("C", "D"));
			matches.Add(new Match("E", "F"));
			foreach (Match m in matches)
			{
				// create an instance of background worker and pass in your "match"
				MatchBGW bgw = new MatchBGW(m);
				// tell the background worker that if it is notified to "
				// report progress" to, to pass itself (background worker object)
				// to this class's SomeoneScored method (same UI thread as textbox)
				bgw.ProgressChanged += SomeoneScored;
				// Now, start the background worker and start the next match
				bgw.RunWorkerAsync();
			}
		}
		// This is called from the background worker via "ReportProgress"
		public void SomeoneScored(object sender, ProgressChangedEventArgs e)
		{
			// Just ensuring that the background worker IS that of what was customized
			if (sender is MatchBGW)
			{
				// get whatever "match" associated with the background worker
				Match m = ((MatchBGW)sender).callingMatch;
				// add it's latest score with appropriate home/away team names
				this.txtAllGoals.Text +=
				    string.Format("{0} {1} - {2} {3}\r\n", 
					m.HomeTeam, m.HomeGoals, m.AwayGoals, m.AwayTeam );
			}
		}
