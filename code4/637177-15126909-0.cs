    public bool ShouldPlay;
    private void InitAudio(object data) {
    
            var OutDevice = new WaveOut();
            var OutStream = new WaveChannel32(new Mp3FileReader(data.ToString()));
            var OutDevice.Init(OutStream);
    
            while(!_exitEvent.WaitOne(50ms)){
                     if(ShouldPlay && !OutDevice.IsPlaying)
                            OutDevice.Play();
                     else if(!ShouldPlay && OutDevice.IsPlaying)
                            OutDevice.Stop();
                }
              OutDevice.Stop();
              OutDevice.Dispose();
              OutStream.Dispose();
        }
