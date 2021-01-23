    public partial class UserControl1 : UserControl
    {
        public event EventHandler AddControl;
        public UserControl1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.AddControl(this, new EventArgs());
        }
    }
