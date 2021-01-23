    Song BGmusic;
    bool songstart = false;
    protected override void LoadContent()
    {
        currentgamescreen = Gamescreen.menuscreen;
        BGmusic = Game.Content.Load<Song>("audio/rockTheDragon");
        if (!songstart)
        {
            MediaPlayer.Play(BGmusic);
        }
     }
