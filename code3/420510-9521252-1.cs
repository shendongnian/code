    private double GetSignalAmplitude(byte[] signal)
    {
        int BytesInSample = 2;
        int signalSize = signal.Length / BytesInSample;
        double Sum = 0.0;
        for (int i = 0; i < signalSize; i++)
        {
            int sample = Math.Abs(BitConverter.ToInt16(signal, i * BytesInSample));
            Sum += sample;
        }            
            
        double amplitude = Sum / signalSize; 
           
        return amplitude;
    }
