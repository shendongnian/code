	private void TakeOverAllScreens()
	{
		foreach (Screen s in Screen.AllScreens)
		{
			if (s != Screen.PrimaryScreen)
			{
				Process.Start(Application.ExecutablePath, "Screen|" + s.Bounds.X + "|" + s.Bounds.Y);
			}
		}
	}
