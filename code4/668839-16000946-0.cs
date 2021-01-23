    struct StartPositions
    {
        public Vector2 pacman;
        public Vector2[] ghosts;
    
        // Constructor accepts a Vector2, and an array of Vector2's.
        public StartPositions(Vector2 pacmanPosIn, Vector2[] ghostsPosIn)
        {
            pacman = pacmanPosIn;
            ghosts = new Vector2[ghostsPosIn.Length];
            for(int a=0;a<ghostsPosIn.Length;a++)
            {
                ghosts[a] = ghostsPosIn[a];
            }
        }
    }
