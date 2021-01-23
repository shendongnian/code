    public class TV:IMediaPlayer
    {
       void Play(){};
    }
    
    public class Radio:IMediaPlayer
    {
       void Play(){};
    }
    
    public interface IMediaPlayer
    {
       void Play():
    }
    
    public class Test
    {
      public void Main()
      {
         IMediaPlayer player = GetMediaPlayer();
         player.Play();
      }
    
    
      private IMediaPlayer GetMediaPlayer()
      {
         if(...)
            return new TV();
         else
            return new Radio();
      }
    }
