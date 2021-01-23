    class Enemy
    {
        public string Name { get; }
        public int InitialHealth { get; }
        public int CurrentHealth { get; }
        public Vector2D Position { get; }
        public Enemy Clone();
    }
    // define enemy prototypes
    Enemy gruntPrototype = new Enemy(...);
    Enemy bugPrototype = new Enemy(...);
    // spawn an enemy
    Enemy enemy = gruntPrototype.Clone();
 
