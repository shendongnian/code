    // Variable declaration
    Song menu_song;
    Song game_song;
    bool isInMenu; //I'll use this instead of the gamestate as example
    
    //In the LoadContent method:
    //remember to add the song to your project. In this case is in 
    //a folder called "music"
     Content.Load<Song>("music/menuSongName"); 
     Content.Load<Song>("music/gameSongName"); 
    
    //In Update method:
    
    if (isInMenu) 
    {
    MediaPlayer.Stop(); //Stop the current audio...
    MediaPlayer.Play(menu_song); //...and start playing the next.
    }
    else
    {
    MediaPlayer.Stop(); //Stop the current audio
    MediaPlayer.Play(game_song); //...and start playing the next.
    }
