	List<KeyType> keysToRemove = new List<KeyType>();
	foreach (var gem in gems)
	{
		gem.Value.Update(gameTime);
		if (gem.Value.BoundingCircle.Intersects(Player.BoundingRectangle))
		{
			OnGemCollected(gem.Value, Player);
			keysToRemove.Add(gem.Key);
		}
	}
	foreach (var key in keysToRemove)
		gems.Remove(key);
