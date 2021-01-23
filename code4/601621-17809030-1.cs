    Models.UsersContext uc = new UsersContext();
    
    Game g = new Game();
    g.UserId = WebSecurity.CurrentUserId;
    g.Wager = int.Parse(BetQuantity);
    uc.GamesList.Add(g);
    uc.SaveChanges();
