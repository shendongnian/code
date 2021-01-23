    public void Speak(Uri mp3FileUri)
    {
        using (var client = new WebClient())
        {
            using (var networkStream = client.OpenRead(mp3FileUri))
            {
                if (networkStream != null)
                {
                    using (var memStream = new MemoryStream())
                    {
                        networkStream.CopyTo(memStream);
                        memStream.Position = 0;                            
                        using (var waveOut = new WaveOut(WaveCallbackInfo.FunctionCallback()))
                        {
                            var waveEvent = new ManualResetEvent(false);
                            waveOut.PlaybackStopped += (sender, e) => waveEvent.Set();
                            waveEvent.Reset();
                            using (var rdr = new Mp3FileReader(memStream))
                            using (var waveStream = WaveFormatConversionStream.CreatePcmStream(rdr))
                            using (var baStream = new BlockAlignReductionStream(waveStream))
                            {
                                waveOut.Init(baStream);
                                waveOut.Play();
                                if (waveOut.PlaybackState != PlaybackState.Stopped)
                                { 
                                    waveEvent.WaitOne(); /* block thread for a while because I don't want async play back                                
                                                            (to be analogical as usage of SoundPlayer Play method) */
                                }
                            }
                        }
                    }
                }
            }
        }
    }
