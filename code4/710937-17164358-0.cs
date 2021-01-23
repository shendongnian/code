    public Form1()
        {
            InitializeComponent();
            t.Interval = 100;
            t.Tick += (s, e) =>
            {
                SendKeys.Send("{HOME}+{END}");
                t.Stop();
            };
    }
    Timer t = new Timer();
    private void button1_Click(object sender, EventArgs e)
    {
            OpenFileDialog open = new OpenFileDialog();
            open.FileName = "I love .NET so much";
            t.Start();
            open.ShowDialog();
    }
