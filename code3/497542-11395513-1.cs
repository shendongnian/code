    public static class Texture
    {
        public static Texture2D Player { get; private set; }
        public static Texture2D BackGround { get; private set; }
        ...
   
        static Texture()
        {
            Player = Content.Textures["Player"];
            BackGround = Content.Textures["BackGround"];
            ...
        }
    }
