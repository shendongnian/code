    private static void playWav(object sender, EventArgs e)
    {
        Thread thread = new Thread(playWavThread);
        thread.Start();
    }
    private static void playWavThread()
    {
        var soundFile = @"C:\sound.wav";
        using (var wfr = new WaveFileReader(soundFile))
        using (WaveChannel32 wc = new WaveChannel32(wfr) { PadWithZeroes = false })
        using (var audioOutput = new DirectSoundOut())
        {
            audioOutput.Init(wc);
            audioOutput.Play();
            while (audioOutput.PlaybackState != PlaybackState.Stopped)
            {
                Thread.Sleep(20);
            }
            audioOutput.Stop();
        }
    }
