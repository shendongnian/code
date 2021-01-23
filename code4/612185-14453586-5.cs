    void SpawnEnemy(int spawnedCount)
    {
        if (EnemyOnMap < 10 && spawnedCount < 100)
        {
            var rd = new Random();
            Enemy e = new Enemy();
            SpawnLocation spawnLoc = new SpawnLocation();
            bool locationOk = false;
            while(!locationOk)
            {
                spawnLoc = spawnLocs[rd.Next(0, spawnLoc.Length)];
                if (!spawnLoc.IsOccupied)
                {
                    locationOk = true; 
                }
            }
            e.SpawnLocation = spawnLoc;
    
            this.Map.AddNewEnemy(e);
        }
    }
