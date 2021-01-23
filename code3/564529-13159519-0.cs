    public partial class MyCustomButton : Control
    {
        public MyCustomButton()
        {
            InitializeComponent();
        }
    
        protected override void OnPaint(PaintEventArgs pe)
        {
            pe.Graphics.DrawString("Show SIP", Font, new SolidBrush(ForeColor), 0, 0);
            // Calling the base class OnPaint
            base.OnPaint(pe);
        }
    }
