    public partial class Form1 : Form
    {
        private Timer timer;
        private MessageHandler theHandler = new MessageHandler();
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += TimerOnTick;
            // Initialize the other labels with static text here
        }
        private void TimerOnTick(object sender, EventArgs eventArgs)
        {
            theHandler.ShowNext(label1);
        }
        private void StartButton_Click(object sender, EventArgs e)
        {
            timer.Start();
        }
    }
