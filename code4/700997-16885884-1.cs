    private async void button2_Click(object sender, EventArgs e)
    {
        var pageNum = 0;
        while(true) //<-- Insert whatever your real condition is here instead of true
        {
            var searchParameters = new PlayerSearchParameters
            {
                Page = ++pageNum,
                League = League.BarclaysPremierLeague,
                Nation = Nation.England,
                Position = Position.CentralForward,
                Team = Team.ManchesterUnited
            };
            await LoginM.SearchItemsAsync(searchParameters);
         }
    }
