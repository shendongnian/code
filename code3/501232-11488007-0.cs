    using System.Windows.Media;
    public void PlayFile(string filename)
    {
        MediaPlayer mplayer = new MediaPlayer();
        mplayer.Open(filename);
        mplayer.Play();
    }
