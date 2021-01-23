    public void stop(int fadeoutTime)
        {
                foreach (var sourceVoice in runningInstances.ToList<SourceVoice>())
                {
                    if (!sourceVoice.IsDisposed)
                    {
                        sourceVoice.Stop();
                        sourceVoice.FlushSourceBuffers();
                        sourceVoice.DestroyVoice();
                        sourceVoice.Dispose();
                    }
                }
                
        }
