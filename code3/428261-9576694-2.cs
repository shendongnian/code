    public void Update(List<Ship> ships) 
    { 
    ...
    
        lock(Projectiles)
        {
            for (int i = 0; i < Projectiles.Count; i++) 
                if (Projectiles[i].Remove) 
                    Projectiles.RemoveAt(i); 
            foreach (Projectile p in Projectiles) 
                p.Update(targetShipPosition); 
        }
    } 
    public void Draw(SpriteBatch spriteBatch) 
    { 
        ...
        lock(Projectiles)
        {
            foreach (Projectile p in Projectiles) 
                p.Draw(spriteBatch); 
        } 
    }
