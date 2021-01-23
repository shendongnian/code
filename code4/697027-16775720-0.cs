    public void PlaySound()
    {
        int i = 0;
        foreach (string musicFile in musicFiles)
        {
            player.SoundLocation = musicFile;
            player.Play();
            Thread.Sleep(1000 * GetMusicDuration[i])
            player.Stop();
            i++;
        }
    }
