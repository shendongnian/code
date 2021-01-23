    System.Media.SoundPlayer _songPlayer ;
    public System.Media.SoundPlayer songPlayer 
    {
      //if you have nay logic to handle ull 
     //get{ if(_songPlayer != null)  return _songPlayer; else null; } or just 
       get;
    }
    public class1(string songPath)
    {
        _songPlayer  = new System.Media.SoundPlayer(songPath);
    }
