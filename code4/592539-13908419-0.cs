    public static MediaElement SoundDelete;
    
    private void MediaInit()
    {
        // ...
        // load your sound file into SoundDelete
        // ...
        BaseGrid.Children.Add(SoundDelete);
    }
    public static void PlaySoundCash()
    {
        System.Diagnostics.Debug.WriteLine(SoundDelete.Position.ToString());
        SoundDelete.Stop();
        SoundDelete.Position = new System.TimeSpan.Zero;
        System.Diagnostics.Debug.WriteLine(SoundDelete.Position.ToString());
        SoundDelete.Play();
    }
