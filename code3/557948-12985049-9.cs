    public partial class UserControl3 : UserControl
    {
        public delegate void ControlFinishedHandler(object sender, EventArgs e);
        public event ControlFinishedHandler ControlFinshedEvent;
        public UserControl3()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ControlFinshedEvent(sender, new EventArgs());
        }
    }
