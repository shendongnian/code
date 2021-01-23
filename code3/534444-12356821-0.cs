    public static Texture2D LoadTexture2D(this ContentManager content, String asset)
    {
        var texture = content.Load<Texture2D>(asset);
        texture.Name = asset;
        return texture;
    }
    var texture = contentManager.LoadTexture2D("textures\\whatever");
    Console.WriteLine(texture.Name); // should be "textures\\whatever"
