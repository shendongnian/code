    public partial class UserControl1 : UserControl
    {
        public delegate void ExitEventHandler(object sender, EventArgs e);
        public event ExitEventHandler ExitEvent; 
        public UserControl1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ExitEvent(this, new EventArgs());
        }
    }
