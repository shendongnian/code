    using (var ms = new MemoryStream(Test.Properties.Resources.aaa))
    using (var rdr = new NAudio.Wave.Mp3FileReader(ms))
    using (var wavStream = NAudio.Wave.WaveFormatConversionStream.CreatePcmStream(rdr))
    using (var baStream = new NAudio.Wave.BlockAlignReductionStream(wavStream))
    using (var waveOut = new NAudio.Wave.WaveOut(NAudio.Wave.WaveCallbackInfo.FunctionCallback())) {
       waveOut.Init(baStream);
       waveOut.Play();
       while (waveOut.PlaybackState == NAudio.Wave.PlaybackState.Playing) {
          System.Threading.Thread.Sleep(100);
       }
    }
