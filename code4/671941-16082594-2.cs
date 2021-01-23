    public partial class PercentageNumericUpDown : NumericUpDown
    {
        public PercentageNumericUpDown()
        {
            InitializeComponent();
        }
        protected override void UpdateEditText()
        {
            this.Text = this.Value + "%";
        }
    }
