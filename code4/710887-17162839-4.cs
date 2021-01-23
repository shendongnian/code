    public partial class ColorProgressBar : System.Windows.Forms.ProgressBar
    {
        public Color BarColorOutside { get; set; }
        public Color BarColorCenter { get; set; }
    
        public ColorProgressBar()
        {
            BarColorOutside = Color.Black;
            BarColorCenter = Color.Yellow;
            InitializeComponent();
            this.SetStyle(ControlStyles.UserPaint, true);
        }
    
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            // your own painting will be added later
        }
    
