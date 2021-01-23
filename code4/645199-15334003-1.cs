     class Program
     {
         static void Main()
         {
             using (var rdr = new Mp3FileReader(filename))
             using (var waveOut = new WaveOut(WaveCallbackInfo.FunctionCallback()))
             {
                  waveOut.Play();
                  while (waveOut.PlaybackState == PlaybackState.Playing)
                  {
                      Thread.Sleep(100);
                  }
             }
         }
      }
