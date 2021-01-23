    class EnemyFactory
    {
     Enemy CreateEnemy(int id)
     {
      if (id == 0)
       return new Snake();
      return new GenericEnemy();
     }
    }
    void LoadLevel()
    {
     // bla bla
     Level level = new Level();
     int enemyId = LoadFromFile();
     level.AddEnemy(EnemyFactory.CreateEnemy(enemyId));
    }
