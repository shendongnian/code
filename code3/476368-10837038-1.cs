    public MusicStoreContext(DbSetProvider provider)
    {
        Albums = provider.CreateDbSet<Album>();
        Artists = provider.CreateDbSet<Artist>();
    }
