    class Dungeon {
        public Level[] Levels { get; private set; }
    class Level {
        public int NumberOfRooms
            { get { return Maze.GetUpperBound(0) * Maze.GetUpperBound(1); }
        public MazePiece[,] Maze { get; private set; }
    }
    class MazePiece {
        private List<Mob> _mobs = new List<Mob>();
        public IEnumerable<Mob> Mobs { get { return _mobs; } }
        public int MobCount { get { return _mobs.Count; } }
    }
    class Mob {
        public string Name { get; private set; }
    }
