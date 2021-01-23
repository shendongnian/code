    using System.ComponentModel;
    [CLSCompliant(true)]
    public class Progressbar : Control {
        
        [CLSCompliant(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        [Browsable(true)]
        [Category("Appearance")]
        [DefaultValue(100)]
        public int Maximum {
            get {
                return _maximum;
            }
            set {
                _maximum = value;
                this.Invalidate();
            }
        }
        
        [CLSCompliant(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        [Browsable(true)]
        [Category("Appearance")]
        [DefaultValue(0)]
        public int Value {
            get {
                return _value;
            }
            set {
                _value = value;
                this.Invalidate();
            }
        }
        
        [CLSCompliant(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        [Browsable(true)]
        [Category("Appearance")]
        [DefaultValue(null.ToString())]
        public Image ProgressbarImage {
            get {
                return _progressbarImage;
            }
            set {
                _progressbarImage = value;
                this.Invalidate();
            }
        }
        
        [CLSCompliant(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        [Browsable(true)]
        [Category("Appearance")]
        [DefaultValue(typeof(Color), "DarkGray")]
        public Color ProgressbarColor {
            get {
                return _progressbarColor;
            }
            set {
                _progressbarColor = value;
                this.Invalidate();
            }
        }
        
        private int _maximum = 100;
        private int _value = 0;
        private Image _progressbarImage = null;
        private Color _progressbarColor = Color.DarkGray;
        
        Progressbar() {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }
        
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e) {
            Graphics g = e.Graphics;
            Rectangle r = this.ClientRectangle;
            ControlPaint.DrawBorder(g, r, Color.Black, ButtonBorderStyle.Solid);
            r.Inflate(-1, -1);
            r.Width = (int.Parse((r.Width 
                            * (_value / _maximum))) - 1);
            if ((r.Width < 1)) {
                return;
            }
            if (_progressbarImage == null) {
                Using (Solidbrush b = new SolidBrush(_progressbarColor)) {
                    g.FillRectangle(b, r);
                }
            }
            else {
                g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(_progressbarImage, r);
            }
        }
    }
