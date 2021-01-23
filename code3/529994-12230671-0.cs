    public frmTimer()
    {
        InitializeComponent();
    }
    private void Form1_Load(object sender, EventArgs e)
    {
        timer1.Start();
    }
    private void timer1_Tick(object sender, EventArgs e)
    {
        Debug.WriteLine(DateTime.Now.ToLongTimeString());
    }
    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
        e.Cancel = true;
        this.Visible = false;
    }
