    public class MapTile
    {
        public Texture2D Texture { get; set; }
        public Rectangle MapRectangle { get; set; }
    
        public MapTile(Rectangle rectangle)
        {
            MapRectangle = rectangle;
        }
    }
    
    public class GrassTile : MapTile
    {    
        public GrassTile(Rectangle rectangle) : base(rectangle)
        {
            Texture = Main.GrassTileTexture;
        }
    }
