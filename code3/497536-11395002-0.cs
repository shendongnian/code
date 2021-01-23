    public class TurretHullInfo
    {
        Texture2D Graphic { get; set; }
        int Rows { get; set; }
        int Columns { get; set; }
    }
    public static class LoadGraphics
    {
        //global variable
        public static TurretHullInfo _blue_turret_hull;
        public static void LoadContent(ContentManager contentManager)
        {
            //loads all the graphics/sprites
            _blue_turret_hull = new TurretHull();
            _blue_turret_hull.Graphic = contentManager.Load<Texture2D>("Graphics/Team Blue/Turret hull spritesheet");
            _blue_turret_hull.Rows = 1;
            _blue_turret_hull.Columns = 11;
        }
    }
    class Turret_hull : GameObject
    {
        public Turret_hull(Game game, String team)
            : base(game)
        {
            if(team == "blue")
                _texture = LoadGraphics._blue_turret_hull.Graphic;     
        }
    }
