        [DllImport("gdi32")]
        private static extern IntPtr CreateEllipticRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect);
        [DllImport("dwmapi")]
        private static extern int DwmEnableBlurBehindWindow(IntPtr hWnd, ref DwmBlurbehind pBlurBehind);
        public struct DwmBlurbehind
        {
            public int DwFlags;
            public bool FEnable;
            public IntPtr HRgnBlur;
            public bool FTransitionOnMaximized;
        }
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            var hr = CreateEllipticRgn(0, 0, Width, Height);
            var dbb = new DwmBlurbehind {FEnable = true, DwFlags = 1, HRgnBlur = hr, FTransitionOnMaximized = false};
            DwmEnableBlurBehindWindow(Handle, ref dbb);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.FillRectangle(new SolidBrush(Color.Black), new Rectangle(0, 0, Width, Height));
        }
