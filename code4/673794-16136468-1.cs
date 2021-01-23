    // ensure rectangle's positions reflect the entity's position before checking.
    List<Vector2> collisionPositions = new List<Vector2> positions;
    hidden = false;
    for (int i = 0; i < asteroids.Count; i++)
    {
        if (player.rectangle.Intersects(asteroids[i].rectangle))
        {
            hidden = true;
            collisionPositions.add(asteroids[i].position);
        }
    }
