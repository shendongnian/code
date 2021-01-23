	private void Counter()
	{
		if (pictureBox.InvokeRequired)
		{
			Action action = Counter;
			pictureBox.Invoke(action);
			return;
		}
		pictureBox.Image = Resources._5;
	}
