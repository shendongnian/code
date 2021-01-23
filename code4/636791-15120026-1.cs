    int touchedCount = 0;
    foreach (CollisionTiles tile in map.CollisionTiles)
    {
            if (player.Collision(tile.Rectangle))
            {
                 touchedCount++;
            }
    }
    if (touchedCount == 0)
    {
        //You did not collide with anything
    }
