    public class FadeInOutSampleProvider : ISampleProvider
    {
        enum FadeState
        {
            Silence,
            FadingIn,
            FullVolume,
            FadingOut,
        }
        private readonly object lockObject = new object();
        private readonly ISampleProvider source;
        private int fadeSamplePosition;
        private int fadeSampleCount;
        private FadeState fadeState;
        public FadeInOutSampleProvider(ISampleProvider source)
        {
            this.source = source;
            this.fadeState = FadeState.FullVolume;
        }
        public void BeginFadeIn(double fadeDurationInMilliseconds)
        {
            lock (lockObject)
            { 
                fadeSamplePosition = 0;
                fadeSampleCount = (int)((fadeDurationInMilliseconds * source.WaveFormat.SampleRate) / 1000);
                fadeState = FadeState.FadingIn;
            }
        }
        public void BeginFadeOut(double fadeDurationInMilliseconds)
        {
            lock (lockObject)
            {
                fadeSamplePosition = 0;
                fadeSampleCount = (int)((fadeDurationInMilliseconds * source.WaveFormat.SampleRate) / 1000);
                fadeState = FadeState.FadingOut;
            }
        }
        public int Read(float[] buffer, int offset, int count)
        {
            int sourceSamplesRead = source.Read(buffer, offset, count);
            lock (lockObject)
            {
                if (fadeState == FadeState.FadingIn)
                {
                    FadeIn(buffer, offset, sourceSamplesRead);
                }
                else if (fadeState == FadeState.FadingOut)
                {
                    FadeOut(buffer, offset, sourceSamplesRead);
                }
                else if (fadeState == FadeState.Silence)
                {
                    ClearBuffer(buffer, offset, count);
                }
            }
            return sourceSamplesRead;
        }
        private static void ClearBuffer(float[] buffer, int offset, int count)
        {
            for (int n = 0; n < count; n++)
            {
                buffer[n + offset] = 0;
            }
        }
        private void FadeOut(float[] buffer, int offset, int sourceSamplesRead)
        {
            int sample = 0;
            while (sample < sourceSamplesRead)
            {
                float multiplier = 1.0f - (fadeSamplePosition / (float)fadeSampleCount);
                for (int ch = 0; ch < source.WaveFormat.Channels; ch++)
                {
                    buffer[offset + sample++] *= multiplier;
                }
                fadeSamplePosition++;
                if (fadeSamplePosition > fadeSampleCount)
                {
                    fadeState = FadeState.Silence;
                    // clear out the end
                    ClearBuffer(buffer, sample + offset, sourceSamplesRead - sample);
                    break;
                }
            }
        }
        private void FadeIn(float[] buffer, int offset, int sourceSamplesRead)
        {
            int sample = 0;
            while (sample < sourceSamplesRead)
            {
                float multiplier = (fadeSamplePosition / (float)fadeSampleCount);
                for (int ch = 0; ch < source.WaveFormat.Channels; ch++)
                {
                    buffer[offset + sample++] *= multiplier;
                }
                fadeSamplePosition++;
                if (fadeSamplePosition > fadeSampleCount)
                {
                    fadeState = FadeState.FullVolume;
                    // no need to multiply any more
                    break;
                }
            }
        }
        public WaveFormat WaveFormat
        {
            get { return source.WaveFormat; }
        }
    }
