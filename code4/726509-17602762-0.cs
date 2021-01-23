    public partial class MyTextBox : TextBox
    {
        public MyTextBox()
        {
            InitializeComponent();
            // Need the following line to enable the OnPaint event
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            // this demonstrates the concept, but doesn't do what you want
            base.OnPaint(e);
            Point p = this.GetPositionFromCharIndex(this.SelectionStart);
            e.Graphics.FillRectangle(Brushes.Aqua, 0, p.Y, this.Width, (int)e.Graphics.MeasureString("A", this.Font).Height);
        }
    }
