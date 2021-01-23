        private NAudio.Wave.WaveIn sourceStream = null;
        private NAudio.Wave.DirectSoundOut waveOut = null;
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (sourceListView.SelectedItems.Count == 0) return;
            //NAudio.Wave.MixingWaveProvider32 mixer=sourceStream.GetMixerLine();
            int deviceNumber = sourceListView.SelectedItems[0].Index;
            sourceStream = new NAudio.Wave.WaveIn();
            sourceStream.DeviceNumber = deviceNumber;
            sourceStream.WaveFormat = new NAudio.Wave.WaveFormat(9600,8, NAudio.Wave.WaveIn.GetCapabilities(deviceNumber).Channels);
            NAudio.Wave.WaveInProvider waveIn = new NAudio.Wave.WaveInProvider(sourceStream);
            waveOut = new NAudio.Wave.DirectSoundOut();
            waveOut.Init(waveIn);
            sourceStream.StartRecording();
            sourceStream.DataAvailable += new EventHandler<NAudio.Wave.WaveInEventArgs>(sourceStream_DataAvailable);
            waveOut.Play();
        }
        void sourceStream_DataAvailable(object sender, NAudio.Wave.WaveInEventArgs e)
        {
            
        }
        private void btnStop_Click(object sender, EventArgs e)
        {
            if (waveOut != null)
            {
                waveOut.Stop();
                waveOut.Dispose();
                waveOut = null;
            }
            if (sourceStream != null)
            {
                sourceStream.StopRecording();
                sourceStream.Dispose();
                sourceStream = null;
            }
        }
