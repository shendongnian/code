    for(int i = gems.Count - 1; i >=0 ; i--)
    {
      gems[i].Value.Update(gameTime);
      if (gems[i].Value.BoundingCircle.Intersects(Player.BoundingRectangle))
      {
          Gem gem = gems[i];
          gems.RemoveAt(i); // Assuming it's a List<Gem>
          OnGemCollected(gem.Value, Player);
      }
     }
