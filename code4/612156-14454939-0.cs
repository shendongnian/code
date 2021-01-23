    public class ConfigsPC : Configs
    {
        public ConfigsPC(Game game)
            : base(game)
        {
            this.Initialize();
            game.Components.Add(this); // add this line
        }
