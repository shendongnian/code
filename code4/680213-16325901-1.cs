      protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            getInfo gI = (getInfo)e.Parameter;
            Team1.Text = gI.Team1;
        }
