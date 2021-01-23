	public Form1()
	{
		InitializeComponent();
		monthCalendar1.MaxSelectionCount = 1;
	}
	private void textBox1_Enter(object sender, EventArgs e)
	{
		monthCalendar1.Visible = true;
	}
	private void textBox1_Leave(object sender, EventArgs e)
	{
		if (!monthCalendar1.Focused)
			monthCalendar1.Visible = false;
	}
	private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
	{
		var monthCalendar = sender as MonthCalendar;
		textBox1.Text = monthCalendar.SelectionStart.ToString();
	}
	private void monthCalendar1_Leave(object sender, EventArgs e)
	{
		var monthCalendar = sender as MonthCalendar;
		monthCalendar.Visible = false;
	}
