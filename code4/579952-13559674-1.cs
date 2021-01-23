        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            MainWindowViewModel mainWindow = new MainWindowViewModel();
            List<Thread> matchThreads = new List<Thread>();
            foreach (Team[] opponents in Program.cm.nextMatches)
            {
                MatchViewModel match = new MatchViewModel();
                match.HomeTeam.Name = opponents[0].Name;
                match.AwayTeam.Name = opponents[1].Name;
                mainWindow.Matches.Add(match);
                Thread matchThread = new Thread(match.PlayMatch);
                matchThreads.Add(matchThread);
                matchThread.Start();
            }
            MainWindow = new MainWindow();
            MainWindow.DataContext = mainWindow;
            MainWindow.Show();
        }
