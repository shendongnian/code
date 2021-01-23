    public partial class Form1 : Form
    {
        private Timer _progresstimer = new Timer();
        private int _progress = 0;
        public Form1()
        {
            InitializeComponent();
            panel1.Paint += new PaintEventHandler(panel1_Paint);
            _progresstimer.Interval = 250;
            _progresstimer.Tick += (s, e) =>
             {
                 if (_progress < 100)
                 {
                     _progress++;
                     panel1.Invalidate();
                     return;
                 }
                 _progress = 0;
                 panel1.Invalidate();
             };
            _progresstimer.Start();
        }
     
        void panel1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.Black, panel1.ClientRectangle);
            e.Graphics.DrawString("StackOverflow", Font, Brushes.Orange, panel1.ClientRectangle);
            var clipRect = new Rectangle(0, 0, (panel1.Width / 100) * _progress, panel1.Height);
            e.Graphics.SetClip(clipRect);
            e.Graphics.FillRectangle(Brushes.Orange, clipRect);
            e.Graphics.DrawString("StackOverflow", Font, Brushes.Black, 0, 0);
        }
    }
