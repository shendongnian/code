    public static class MyGameEngine
    {
        private static Game game;
        public static Game Game
        {
            get
            {
                if (game == null)
                    game = new Game();
                return game;
            }
        }
    }
    
