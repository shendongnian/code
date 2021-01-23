    private static void SubmitChanges() {
    while(true) {
        try {
            using(GameDBDataContext db = new GameDBDataContext()){
                foreach(IHero hero in world.Entities.BattleEntities.OnlineHeros.Values) {
                    hero.UpdateRecord(db);
                }
                db.SubmitChanges();
            }
        } catch(Exception ex) {
            Console.WriteLine(ex.ToString());
        }
        Thread.Sleep(1000);
    }
