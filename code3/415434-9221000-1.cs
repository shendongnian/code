    players.Find(p => p.Id == tempID).Shoot();
    ...
    static class Extensions
    {
        public static void Shoot(this Player p)
        {
            p.shots.Add(new Shot(p.yPos));
        }
    }
