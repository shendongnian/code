    public class Animation
    {
        readonly Timer _animtimer = new Timer();
        public List<Image> Frames;
        public int FrameIndex;
        private Button _target;
        private PictureBox _ptarget;
        public void Target(PictureBox target)
        {
            _ptarget = target;
        }
        public void Target(Button target)
        {
            _target = target;
        }
        public int FrameSpeed
        {
            get { return _animtimer.Interval; }
            set { _animtimer.Interval = value; }
        }
        public Animation()
        {
            Frames  = new List<Image>();
            _animtimer.Interval = 100;
            _animtimer.Tick += Update;
        }
        public void Play()
        {
            _animtimer.Start();
        }
        public void AddFrame(string file)
        {
            Frames.Add(Image.FromFile(file));
        }
        public void Stop()
        {
            _animtimer.Stop();
        }
        private void Update(object sender, EventArgs eventArgs)
        {
            FrameIndex++;
            if (FrameIndex == Frames.Count)
            {
                FrameIndex = 0;
            }
            _target.Image = Frames[FrameIndex];
            _ptarget.Image = Frames[FrameIndex];
        }
        public static implicit operator Image(Animation a)
        {
            return a.Frames[a.FrameIndex];
        }
    }
