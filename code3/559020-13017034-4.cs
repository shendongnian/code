    public void Load(ContentManager content)
    {
        myBullet = content.Load<Texture2D>("bullet");
        Debug.Assert(null != myBullet);
    }
