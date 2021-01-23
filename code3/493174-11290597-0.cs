    public partial class FormWithVersionNumber : Form
    {
        public override sealed string Text
        {
            get
            {
                return base.Text + " 1.0.0.0";
            }
            set
            {
                base.Text = value + " 1.0.0.0";
            }
        }
     
    
        public FormWithVersionNumber()
        {
            InitializeComponent();
    
            Text = "Some Title";
        }
    }
