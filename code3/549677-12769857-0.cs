    public static class PlayerBuilder
    {
        public static Player BuildPlayer(BuildDefinition definition)
        {
            //logic in here to build a player -- pseudo-return value below as an example
            var strategy = new PlayerMovementStrategy();
            return new Player(strategy);
        }
    }
