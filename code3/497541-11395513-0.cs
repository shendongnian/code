    public static class Texture
    {
        Texture2D Player { get; private set; }
        Texture2D BackGround { get; private set; }
        ...
   
        static Texture()
        {
            Player = Content.Textures["Player"];
            BackGround = Content.Textures["BackGround"];
            ...
        }
    }
