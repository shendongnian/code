    static public Icon
    {
        public Texture2D Texture; // starts with null...
        static public Icon PlayButton = new Icon(); // Not a null reference, even though the texture hasn't been loaded yet...
    }
    public class MenuButton
    {
        public MenuButton()
        {
            this.Icon = Icon.PlayButton; // Again, not a null reference...
        }
        public Icon Icon { get; set; }
        public void Draw()
        {
            SpriteBatch.Draw(this.Icon.Texture); // etc...
        }
    }
