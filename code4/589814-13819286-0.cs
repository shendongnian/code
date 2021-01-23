    public partial class FormTimed : Form
    {
        private String _OriginalText;
        private DateTime _StartTime;
        private Timer _Timer;
        public FormTimed()
        {
            InitializeComponent();
            InitializeTimer();
            Duration = TimeSpan.FromSeconds(10);
        }
        [DefaultValue(typeof(TimeSpan), "00:00:10")]
        public TimeSpan Duration { get; set; }
        public override string Text
        {
            get
            {
                return _OriginalText;
            }
            set
            {
                _OriginalText = value;
                base.Text = value;
            }
        }
        public void DisableTimer()
        {
            _Timer.Stop();
            base.Text = _OriginalText;
        }
        public void ResetTimer()
        {
            _StartTime = DateTime.UtcNow;
            _Timer.Start();
        }
        public new DialogResult ShowDialog()
        {
            StartTimer();
            return base.ShowDialog();
        }
        public new DialogResult ShowDialog(IWin32Window owner)
        {
            StartTimer();
            return base.ShowDialog(owner);
        }
        private void InitializeTimer()
        {
            _Timer = new Timer();
            _Timer.Interval = 100;
            _Timer.Tick += OnTimerTick;
        }
        private void OnTimerTick(object sender, EventArgs e)
        {
            var finishTime = _StartTime + Duration;
            var remainingDuration = finishTime - DateTime.UtcNow;
            if (remainingDuration < TimeSpan.Zero)
            {
                Close();
            }
            base.Text = _OriginalText + " (" + (int)remainingDuration.TotalSeconds + ")";
        }
        private void StartTimer()
        {
            _StartTime = DateTime.UtcNow;
            _Timer.Start();
        }
    }
