    public partial class Form1 : Form
    {
        private int _handle;
        private int _pos;
        private BASSTimer _timer;
        private Visuals _visuals;
        public Form1()
        {
            InitializeComponent();
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            bool spectrum3DVoicePrint = _visuals.CreateSpectrum3DVoicePrint(_handle, pictureBox1.CreateGraphics(),
                                                                            pictureBox1.Bounds, Color.Cyan, Color.Green,
                                                                            _pos, false, true);
            _pos++;
            if (_pos >= pictureBox1.Width)
            {
                _pos = 0;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            string file = "..\\..\\mysong.mp3";
            if (Bass.BASS_Init(-1, 44100, BASSInit.BASS_DEVICE_DEFAULT, Handle))
            {
                _handle = Bass.BASS_StreamCreateFile(file, 0, 0, BASSFlag.BASS_DEFAULT);
                if (Bass.BASS_ChannelPlay(_handle, false))
                {
                    _visuals = new Visuals();
                    _timer = new BASSTimer((int) (1.0d/10*1000));
                    _timer.Tick += timer_Tick;
                    _timer.Start();
                }
            }
        }
    }
