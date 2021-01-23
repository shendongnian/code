    [System.ComponentModel.DefaultEvent("CheckedChanged")]
    public partial class CheckedLabel : UserControl
    {
        public event EventHandler CheckedChanged;
        public CheckedLabel()
        {
            InitializeComponent();
        }
        public override string Text
        {
            get
            {
                return lblDisplay.Text;
            }
            set
            {
                lblDisplay.Text = value;
            }
        }
        private void cbCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            // Pass the checkbox event
            ButtonBase b = sender as ButtonBase;
            b.Text = lblDisplay.Text;
            CheckedChanged(sender, e);
        }        
    }
