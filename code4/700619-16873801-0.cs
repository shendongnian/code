    IMobileServiceTable<Game> todoTable = App.MobileService.GetTable<Game>();
    string player = Player.Text;
    IEnumerable<string> emails = await todoTable
        .Where(game => game.PlayerName == player)
        .Select(game => game.PlayerMail)
        .ToEnumerableAsync();
    string playerMail = emails.FirstOrDefault();
