    public class Tile
    {
        private string _texturePath = String.Empty;
        private Texture2D _texture;
        protected virtual string TexturePath { private get { return _texturePath; } set { _texturePath = value; } }
        public Tile()
        {
            if (!string.IsNullOrWhiteSpace(TexturePath))
                _texture = LoadTexture(TexturePath);
        }
        private Texture2D LoadTexture(string texturePath)
        {
            throw new NotImplementedException();
        }
    }
    internal class Texture2D
    {
    }
    public sealed class Free:Tile
    {
        protected override string TexturePath
        {
            set
            {
                if (value == null) throw new ArgumentNullException("value");
                base.TexturePath = "Content/wall.png";
            }
        }
    }
