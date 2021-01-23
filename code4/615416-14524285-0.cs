    protected override void LoadContent()
    {
        currentgamescreen = Gamescreen.menuscreen;
        if (!songstart)
        {
            BGmusic = Game.Content.Load<Song>("audio/rockTheDragon");
            MediaPlayer.Play(BGmusic);
        }
     }
