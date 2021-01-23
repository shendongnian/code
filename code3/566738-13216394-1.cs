    public abstract class Tile
    {
        public abstract Texture2D Texture { get; }
        public abstract string TexturePath { get; }
    }
    public class Free : Tile
    {
       private static Texture2D texture;
       private static string texture_path;
       public override Texture2D Texture { get { return texture; } }
       public override string TexturePath { get { return texture_path; } }
    }
    // and similarly for Wall
