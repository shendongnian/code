    private volatile bool _QuitThread;
    private void playWav(object sender, EventArgs e)
    {
        _QuitThread = false;
        Thread thread = new Thread(playWavThread);
        thread.Start();
    }
    // This method should be called when the music should stop. Perhapse when a button has been pressed.
    private void StopTheMusic() 
    {
        _QuitThread = true;
    }
    private void playWavThread()
    {
        var soundFile = @"C:\sound.wav";
        using (var wfr = new WaveFileReader(soundFile))
        using (WaveChannel32 wc = new WaveChannel32(wfr) { PadWithZeroes = false })
        using (var audioOutput = new DirectSoundOut())
        {
            audioOutput.Init(wc);
            audioOutput.Play();
            while (!_QuitThread && audioOutput.PlaybackState != PlaybackState.Stopped)
            {
                Thread.Sleep(20);
            }
            audioOutput.Stop();
        }
    }
