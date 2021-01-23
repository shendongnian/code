    public GameResult PurchaseGameItem(int itemId)
    {
        using (var entities = new GameEntities())
        {
            var p1 = entities.Items.Where(p => p.ID == itemId).FirstOrDefault();
            var p2 = entities.Items.Where(p => p.ID == itemId).FirstOrDefault();
            p1.Coins = 1;
            p2.Coins = 2;
            entities.SaveChanges();
        }
        return GameResult.Success;
    }
