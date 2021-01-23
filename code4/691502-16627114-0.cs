    private Stack<Gem> gems = new Stack<Gem>();
    private Stack<Enemy> enemies = new Stack<Enemy>();
    
    /// <summary>
    /// Animates each gem and checks to allows the player to collect them.
    /// </summary>
    private void UpdateGems(GameTime gameTime)
    {
        var newGems = new Stack<Gem>(this.gems.Count);
         
        while (this.gems.Count > 0)    
        {
            var gem = this.gems.Pop();
            gem.Update(gameTime);
            if (gem.BoundingCircle.Intersects(Player.BoundingRectangle))
            {
                OnGemCollected(gem, Player);
            }
            else
            {
                newGems.Push(gem);
            }
        }
        this.gems = newGems;
    }
