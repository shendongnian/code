    class Enemy
    {
        public static int NewEnemySpeed { get; set;}
        public int Speed {get; set;}
        public Enemy()
        {
            Speed = NewEnemySpeed;
        }
    }
