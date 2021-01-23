    NewUser newUser = new NewUser();
    newUser.Show();
    newUser.Closed += (object sender, EventArgs e) =>
    {
        player = new Player
        {
            PlayerName = newUser.txtPlayerName.Text,
        };
        // you aren't going to be able to catch timeout
        // errors in async method calls
        client.GetTableListAsync();
        
        // we can initiate login even if TableList isn't loaded yet
        client.LoginAsync(player.PlayerName);
        client.LoginCompleted += (s2, e2) => {
            // publish player logged in
            client.PublishAsync(String.Format("{0} is logged in", player.PlayerName));
        }
    }
