    protected override void Update(GameTime gameTime)
    {
        for (int i = 0; i < Enemies.Count; i++)
        {
            //If player intersects enemy
            if ( player.Bounds.Intersects(Enemies[i].Bounds) )
            {
                Enemies.RemoveAt(i);
                i--;
                continue;
            }               
        }
    }
    
    
    protected override void Draw(GameTime gameTime)
    {
        foreach (Enemy enemy in Enemies)
        {
            spriteBatch.Draw(enemy.texture, enemy.position, Color.White);
        }
    }
