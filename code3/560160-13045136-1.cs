    private MonthCalendar _monthCalendar;
    public Form1()
    {
        InitializeComponent();
        // invisible on startup
        _monthCalendar.Visible = false;
        _monthCalendar.MaxSelectionCount = 1;
    }
    private void button1_Click(object sender, EventArgs e)
    {
        //show when needed
        _monthCalendar.Show();
    }	
	private void textBox1_Enter(object sender, EventArgs e)
	{
		_monthCalendar.Show();
	}
	private void textBox1_Leave(object sender, EventArgs e)
	{
		if (!_monthCalendar.Focused)
			_monthCalendar.Visible = false;
	}
	private void monthCalendar_DateSelected(object sender, DateRangeEventArgs e)
	{
		var monthCalendar = sender as MonthCalendar;
		textBox1.Text = monthCalendar.SelectionStart.ToString();
	}
	private void monthCalendar_Leave(object sender, EventArgs e)
	{
		var monthCalendar = sender as MonthCalendar;
		monthCalendar.Visible = false;
	}
