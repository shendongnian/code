    public partial class UserControl2 : UserControl
    {
        public delegate void ControlFinishedHandler(object sender, EventArgs e);
        public event ControlFinishedHandler ControlFinshedEvent;
        public UserControl2()
        {
            InitializeComponent();
        }
        public string SetLogonType { get; set; }
        private void button1_Click(object sender, EventArgs e)
        {
            ControlFinshedEvent(sender, new EventArgs());
        }
    }
