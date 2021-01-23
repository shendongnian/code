    private WaveOut waveOut;
    private void button1_Click(object sender, EventArgs e)
    {
      StartStopSineWave();
    }
    private void StartStopSineWave()
    {
      if (waveOut == null)
      {
        var sineWaveProvider = new SineWaveProvider32();
        sineWaveProvider.SetWaveFormat(16000, 1); // 16kHz mono
        sineWaveProvider.Frequency = 1000;
        sineWaveProvider.Amplitude = 0.25f;
        waveOut = new WaveOut();
        waveOut.Init(sineWaveProvider);
        waveOut.Play();
      }
      else
      {
        waveOut.Stop();
        waveOut.Dispose();
        waveOut = null;
      }
    }
