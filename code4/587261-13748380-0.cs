       Hide();
	if(a > b)
	{
		label.Text = "a is greater than b";
		Show();
		System.Windows.Forms.Application.DoEvents();
		Thread.Sleep(50000);
	}
