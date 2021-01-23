    class EnemyClass
    {
        public string Name { get; }
        public int InitialHealth { get; }
        public Enemy Spawn();
    }
    class Enemy
    {
        public EnemyClass Class { get; }
        public int CurrentHealth { get; }
        public Vector2D Position { get; }
    }
    // define enemy classes
    EnemyClass gruntClass = new EnemyClass(...);
    EnemyClass bugClass = new EnemyClass(...);
    // spawn an enemy
    Enemy enemy = gruntClass.Spawn();
