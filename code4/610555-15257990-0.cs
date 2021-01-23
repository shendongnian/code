    private static Microphone mic = Microphone.Default;
    private static SpeexEncoder encoder = CreateEncoder();
        private static SpeexEncoder CreateEncoder()
        {
            BandMode mode = GetBandMode(mic.SampleRate);
            SpeexEncoder encoder = new SpeexEncoder(mode);
            // set encoding quality to lowest (which will generate the smallest size in the fastest time)
            encoder.Quality = 1;
            return encoder;
        }
        private static byte[] EncodeSpeech(byte[] buf, int len)
        {
            int inDataSize = len / 2;
            ...
