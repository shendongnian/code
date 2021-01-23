    for (int i = 0; i < 5; i++)
    {
        if (objectList.Count < 50) // Maximum asteroids on screen
        {
            asteroid = new Asteroid();
            objectList.Add(asteroid);
        }
    }
