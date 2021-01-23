    public sealed partial class Form1 : Form
    {
        readonly Subject<Unit> _button2Subject = new Subject<Unit>();
        private bool shouldRun = false;
        public Form1()
        {
            InitializeComponent();
        }
        async Task CreateAsyncHandler()
        {
            Text = "Initializing";
            while (shouldRun)
            {
                await Task.Delay(1000);
                Text = "Waiting for Click";
                await _button2Subject.FirstAsync();
                Text = "Click Detected!";
                await Task.Delay(1000);
                Text = "Restarting";
            }
        }
        async void button1_Click(object sender, EventArgs e)
        {
            shouldRun = true;
            await CreateAsyncHandler();
        }
        void button2_Click(object sender, EventArgs e)
        {
            _button2Subject.OnNext(Unit.Default);
        }
        void button3_Click(object sender, EventArgs e)
        {
            shouldRun = false;
        }
    }
