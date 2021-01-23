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
             // Pass the checkbox event as an ultra-shallow copy
            CheckBox b = new CheckBox();
            b.Checked = cbCheckbox.Checked;
            b.Text = lblDisplay.Text;
            CheckedChanged(b, e);
        }        
    }
