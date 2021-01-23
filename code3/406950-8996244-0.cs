    //class that represents one sound effect instance PLUS restart flag
    public class Sound
    {
        SoundEffectInstance instance;
        bool restart;
        public Sound(SoundEffectInstance i)
        {
            instance = i;
            restart = false;
        }
        public bool PlayingOrRestarting()
        {
            return State == SoundState.Playing || restart;
        }
        public void Update()
        {
            if (restart)
            {
                instance.Play();
                restart = false;
            }
        }
        public void Play()
        {
            instance.Play();
        }
        public void Restart()
        {
            instance.Stop();
            restart = true;
        }
        public void Stop()
        {
            instance.Stop();
            restart = false;
        }
        public SoundState State
        {
            get { return instance.State; }
        }
        public float Volume
        {
            set { instance.Volume = value; }
            get { return instance.Volume; }
        }
    }
