    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            listener = new PollingListener(this);
        }
        PollingListener listener;
        private void Form1_Load(object sender, EventArgs e)
        {
            listener.Polled += new EventHandler<EventArgs>(listener_Poll);
        }
        void listener_Poll(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("ding.");
        }
    }
