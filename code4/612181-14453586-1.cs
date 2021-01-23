    var spawnLoc = new SpawnLocation[10];
    if (RandomPosition)
    {
        for (int i = 0; i < spawnLoc .Length; i++)
        {
            spawnLoc[i] = // auto define using algorithm / logic
        }
    }
    else
    {
        spawnLoc[0] = // manually define spawn location
        spawnLoc[1] = 
        ...
        ...
        spawnLoc[9] = 
    }
    var rd = new Random();
    var enemies = new Enemy[100];
    for (int i = 0; i < enemies.Length; i++)
    {
        enemies[i].SpawnLocation = spawnLoc[rd.Next(0, spawnLoc.Length)];
    }
