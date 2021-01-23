    public class Songs
    {
        static Songs _instance;
        public static Songs Instance
        { 
            get { return _instance ?? new Songs(); }
        }
        // Do you timer stuff here
     
        // Allow the ability to access the timer stuff also.
    }
    // in AudioPlayer
    override OnUserAction(BackgroundAudioPlayer player, AudioTrack track, UserAction action, object param)
    {
        Songs.Instance.GetStuff
        NotifyComplete();
    }
