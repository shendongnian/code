    private MonthCalendar _monthCalendar;
    public Form1()
    {
        InitializeComponent();
        // invisible on startup
        _monthCalendar.Visible = false;
    }
    private void button1_Click(object sender, EventArgs e)
    {
        //show when needed
        _monthCalendar.Show();
    }
