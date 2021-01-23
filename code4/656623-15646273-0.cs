	private System.Diagnostics.Stopwatch Watch = new System.Diagnostics.Stopwatch();
	private string _KeysPressed;
	public string KeysPressed
	{
		get { return _KeysPressed; }
		set 
		{
			Watch.Stop();
			if (Watch.ElapsedMilliseconds < 300)
				_KeysPressed += value;
			else
				_KeysPressed = value;
			Watch.Reset();
			Watch.Start();
		}
	}        
	private void KeyUpEvent(object sender, KeyEventArgs e)
	{
		KeysPressed = e.KeyCode.ToString();
		if (KeysPressed == "AB")
			lblEventMessage.Text = "You've pressed A B";
		else if (KeysPressed == "ABC")
			lblEventMessage.Text = "You've pressed A B C";
		else
			lblEventMessage.Text = "C-C-C-COMBOBREAKER!!!";
	}
