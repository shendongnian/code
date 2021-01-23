    var spawnLoc = new SpawnLocation[10];
    for (int i = 0; i < spawnLoc .Length; i++)
    {
        spawnLoc[i] = // define spawn location
    }
    var rd = new Random();
    var enemies = new Enemy[100];
    for (int i = 0; i < enemies.Length; i++)
    {
        enemies[i].SpawnLocation = spawnLoc[rd.Next(0, spawnLoc.Length)];
    }
