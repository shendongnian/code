    var reader = new AudioFileReader();
    var mySampleProvider = new MySampleProvider(reader);
    WaveFileWriter.CreateWaveFile(mySampleProvider, "example.wav");
 
    ...
    class MySampleProvider: ISampleProvider
    {
        private readonly ISampleProvider source;
        public MySampleProvider(ISampleProvider source)
        {
            this.source = source;
        }
        public int Read(float[] buffer, int offset, int count)
        {
            int samplesRead = source.Read(buffer, offset, count);
            // TODO: examine and optionally change the contents of buffer
            return samplesRead;
        }
        public WaveFormat WaveFormat
        {
            get { return source.WaveFormat; }
        }
    }
