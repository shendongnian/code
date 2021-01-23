    class MediaPlayer{
    System.Media.SoundPlayer soundPlayer;
    public MediaPlayer(MemoryStream stream){
       soundPlayer = new System.Media.SoundPlayer(stream);
       soundPlayer.LoadCompleted += new AsyncCompletedEventHandler(player_LoadCompleted);
       soundPlayer.Load();
    }
    public void Play(){
	   
	   soundPlayer.Play();
	  
    }
    // Handler for the LoadCompleted event.
    private void player_LoadCompleted(object sender, AsyncCompletedEventArgs e){   
	   Console.WriteLine("LoadCompleted"); 
    } 
    }
