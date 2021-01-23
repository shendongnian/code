    public partial class TestTapAndHold : UserControl
    {
        private string showText = "Tap Me";
        private DateTime mouseDown;
        private const int holdTime = 500;
        public TestTapAndHold()
        {
            InitializeComponent();
            this.Paint += drawText;
        }
        public delegate void OnTapAndHold(EventArgs e);
        public event OnTapAndHold TapAndHold;
        private void drawText(object sender, PaintEventArgs e)
        {
            using (var drawBrush = new SolidBrush(Color.Black))
            {
                e.Graphics.DrawString(showText, Font, drawBrush, new Point(5,3));
            }
        }
        protected override void OnClick(EventArgs e)
        {
            if (DateTime.Now.Subtract(mouseDown).Milliseconds >= holdTime)
            {
                showText = "Tap Hold";
                TapAndHold?.Invoke(e);
            } else
            {
                base.OnClick(e);
                showText = "Tapped";
            }
            Invalidate();
        }
        private void TestTapAndHold_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = DateTime.Now;
        }
    }
