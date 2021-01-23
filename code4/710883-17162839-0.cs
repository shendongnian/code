    public partial class ColorProgressBar : System.Windows.Forms.ProgressBar
    {
        public ColorProgressBar()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.UserPaint, true);
            // etc, other initializations
        }
