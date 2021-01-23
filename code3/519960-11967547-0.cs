    public void LoadAllTextures()
    {
        foreach(string s in texturesToBeLoaded)
        {
            TextureData data = LoadTexture(s);
            // do something with data here
        }
    }
    public Texture2D LoadTexture(string filename)
    {
        Texture2D texture = content.Load<Texture2D>(filename);
        return texture;
    }
