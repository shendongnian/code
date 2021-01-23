    public partial class frmTransparentBackcolor : Form
    {
        public frmTransparentBackcolor()
        {
            InitializeComponent();
            //set the backcolor and transparencykey on same color.
            this.BackColor = Color.LimeGreen;
            this.TransparencyKey = Color.LimeGreen;
        }
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.LimeGreen, e.ClipRectangle);
        }
    }
