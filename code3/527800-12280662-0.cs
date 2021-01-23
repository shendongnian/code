    using System; 
    using System.ComponentModel; 
    using NAudio.Wave; 
     
    namespace Media 
    { 
        public partial class AudioInputToolbox : Component 
        {
            private WaveInEvent waveIn = null;
            private DirectSoundOut waveOut = null;
            public int SampleRate { get; set; } 
            public int BitsPerSample { get; set; } 
            public int Channels { get; set; }
    
            public AudioInputToolbox() 
            { 
                InitializeComponent(); 
     
                SampleRate = 22050; 
                BitsPerSample = 16; 
                Channels = 1; 
            } 
     
            public void BeginReading(int deviceNumber) 
            {
                if (waveIn == null) 
                {
                    waveIn = new WaveInEvent(); 
                    waveIn.DeviceNumber = deviceNumber; 
                    waveIn.WaveFormat = new NAudio.Wave.WaveFormat(SampleRate, BitsPerSample, Channels);
                    waveIn.StartRecording(); 
                } 
            }
     
            public void BeginLoopback() 
            {
                if (waveIn != null && waveOut == null)
                {
                    waveOut = new DirectSoundOut(DirectSoundOut.DSDEVID_DefaultPlayback, 300);
                    waveOut.Init(new WaveInProvider(waveIn));
                    waveOut.Play();
                }
            }
    
            public void EndReading() 
            {
                if (waveIn != null) 
                { 
                    waveIn.StopRecording(); 
                    waveIn.Dispose(); 
                    waveIn = null; 
                } 
            } 
     
            public void EndLoopback() 
            {
                if (waveOut != null)
                {
                    waveOut.Stop();
                    waveOut.Dispose();
                    waveOut = null;
                }
            } 
        } 
    } 
