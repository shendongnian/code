    System.Media.SoundPlayer _songPlayer ;
    public System.Media.SoundPlayer songPlayer 
    {
     get{ if(_songPlayer != null)  return _songPlayer; else null; }
    }
    public class1(string songPath)
    {
        _songPlayer  = new System.Media.SoundPlayer(songPath);
    }
