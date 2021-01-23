    public class Enemy
    {
        public Enemy()
        {
            EnemyState = new EnemyState { IsDirty = true, Position = Vector2.Zero };
            Speed = 3.0f;
        }
    
        public EnemyState State { get; set }
        public float Speed { get; set; }
    }
    
    public class EnemyState
    {
        public bool IsDirty { get; set }
        public Vector2 Position { get; set; }
    }
    
    protected override void Update(GameTime gameTime)
    {
        float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
        
        // If should spawn enemy
        // var enemy = new Enemy();
        // enemy.State.Position = // TODO insert starting position
        // enemies.Add(enemy);
        // Find all enemies that should be moved
        // Set IsDirty = true;
        
        // Move each enemy that IsDirty
        timer -= elapsed;
        if (timer < 0)
        {
            foreach (Enemy enemy in enemies.Where(e => e.State.IsDirty))
            {
                enemy.State.Position.X += enemy.Speed;
                enemy.State.IsDirty = false;
            }
    
            timer = TIMER; //Reset Timer
        }
    }
