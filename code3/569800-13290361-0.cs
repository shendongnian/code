    interface IVolSetter { void SetVolume(int level); }
    class XpVolSetter : IVolSetter
    {
        public void SetVolume(int level)
        {
            // use waveOutSetVolume?
        }
    }
    using CoreAudioApi;
    class VistaVolSetter : IVolSetter
    {
        public void SetVolume(int level)
        {
            // use CoreAudioApi
        }
    }
    class VolSetterFactory
    {
        public IVolSetter GetForMyOS()
        {
            return Environment.OSVersion.Version.Major >= 6
                ? new VistaVolSetter();
                : new XpVolSetter();
        }
    }
