    [ContentSerializerRuntimeType("BasicDemo.Map, BasicDemo")]
    public class DemoMapContent
    {
        public int TileWidth;
        public int TileHeight;
        public List<DemoMapLayerContent> Layers = new List<DemoMapLayerContent>();
    }
    [ContentSerializerRuntimeType("BasicDemo.Layer, BasicDemo")]
    public class DemoMapLayerContent
    {
        public int Width;
        public int Height;
        public DemoMapTileContent[] Tiles;
    }
    [ContentSerializerRuntimeType("BasicDemo.Tile, BasicDemo")]
    public class DemoMapTileContent
    {
        public ExternalReference<Texture2DContent> Texture;
        public Rectangle SourceRectangle;
        public SpriteEffects SpriteEffects;
    }
