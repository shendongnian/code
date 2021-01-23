    public struct BlockProperty
    {
        public Texture2D Texture;
        public string Name;
    }
    public class BlockProperties
    {
        static readonly List<BlockProperty> Blocks;
        public static readonly BlockProperty Dirt;
        public static readonly BlockProperty Grass;
        public static readonly BlockProperty Wall;
        static BlockProperties( )
        {
            ContentManager Content = Game1.Instance.Content;
            Blocks = new List<BlockProperty>( ) 
            { 
                (Dirt = new BlockProperty( ) { Name = "Dirt", Texture = Content.Load<Texture2D>( "textures/dirt" ) }),
                (Grass = new BlockProperty( ) { Name = "Grass", Texture = Content.Load<Texture2D>( "textures/grass" ) }),
                (Wall = new BlockProperty( ) { Name = "Wall", Texture = Content.Load<Texture2D>( "textures/wall" ) }),
            };
        }
        public static BlockProperty ByName( string name )
        {
            return Blocks.FirstOrDefault( b => b.Name == name );
        }
    }
    public class Block
    {
        public BlockProperty BlockType;
        pulic Vector2 Position;
        public Block( BlockProperty block )
        {
            this.BlockType = block;
        }
         public Block( string block )
        {
            this.BlockType = BlockProperties.ByName(block);
        }
    }
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
    
        public static Game1 Instance { get; private set; }
        
        Block Block;
        public Game1( )
        {
            Instance = this;
            graphics = new GraphicsDeviceManager( this );
        }
        protected override void LoadContent( )
        {
            Block = new Block("Dirt") { Position = new Vector2(100,100) };
        }
    }
