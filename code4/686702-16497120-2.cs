	var itemsToRemove = new List<KeyValuePair<TKey, TValue>>();
	foreach (var gem in gems)
	{
		gem.Value.Update(gameTime);
		if (gem.Value.BoundingCircle.Intersects(Player.BoundingRectangle))
			itemsToRemove.Add(gem);
	}
	foreach (var item in itemsToRemove)
	{
		gems.Remove(item.Key);
		OnGemCollected(item.Value, Player);
	}
