    //spawns the enemies.
    public void LoadEnemies()
    {
        int randY = random.Next(100, 500);
        if (spawn > 1)
        {
            spawn = 0;
            if (enemies.Count() < 4)
                enemies.Add(new Enemies(Content.Load<Texture2D>("meteor"), new Vector2(1110, randY)));
        }
        //Here's where the error lies because of the bulletcolliding (I think)
        for (int i = 0; i < enemies.Count; i++)
        {
            if (!enemies[i].isVisible || enemies[i].bulletColliding)
            {
                enemies[i].bulletColliding = false;
                enemies.RemoveAt(i);
                i--;
            }
        }
    }
