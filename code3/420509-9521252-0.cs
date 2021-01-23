    private void Initialize()
    {
        Microphone microphone = Microphone.Default;
        // 100 ms is a minimum buffer duration
        microphone.BufferDuration = TimeSpan.FromMilliseconds(100);  
        DispatcherTimer updateTimer = new DispatcherTimer()
        {
            Interval = TimeSpan.FromMilliseconds(0.1)
        };
        updateTimer.Tick += (s, e) =>
        {
            FrameworkDispatcher.Update();
        };
        updateTimer.Start();
        byte[] microphoneSignal = new byte[microphone.GetSampleSizeInBytes(microphone.BufferDuration)];
        microphone.BufferReady += (s, e) =>
        {
            int microphoneDataSize = microphone.GetData(microphoneSignal);
            double amplitude = GetSignalAmplitude(microphoneSignal);
            // do your stuff with amplitude here
        };
        microphone.Start();
    }
