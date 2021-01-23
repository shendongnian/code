	int keyboardDelay, keyboardSpeed;
	using (var key = Registry.CurrentUser.OpenSubKey(@"Control Panel\Keyboard"))
	{
		Debug.Assert(key != null);
		keyboardDelay = 1;
		int.TryParse((String)key.GetValue("KeyboardDelay", "1"), out keyboardDelay);
		keyboardSpeed = 31;
		int.TryParse((String)key.GetValue("KeyboardSpeed", "31"), out keyboardSpeed);
	}
	maxRepeatedCharacters = 30; // repeat char 30 times
	var startTimer = new System.Windows.Forms.Timer {Interval = keyboardSpeed};
	startTimer.Tick += startTimer_Tick;
	startTimer.Start();
	var repeatTimer = new System.Windows.Forms.Timer();
	repeatTimer.Interval += keyboardDelay;
	repeatTimer.Tick += repeatTimer_Tick;
    //...
	private static void repeatTimer_Tick(object sender, EventArgs e)
	{
		PostMessage(MemoryHandler.GetMainWindowHandle(),
				   (int)KeyCodes.WMessages.WM_KEYDOWN,
				   (int)KeyCodes.VKeys.VK_TAB, 0);
		PostMessage(MemoryHandler.GetMainWindowHandle(),
					(int)KeyCodes.WMessages.WM_CHAR,
					(int)KeyCodes.VKeys.VK_TAB, 0);
		counter++;
		if (counter > maxRepeatedCharacters)
		{
			Timer timer = sender as Timer;
			timer.Stop();
		}
	}
	private static void startTimer_Tick(object sender, EventArgs eventArgs)
	{
		Timer timer = sender as Timer;
		timer.Stop();
		PostMessage(MemoryHandler.GetMainWindowHandle(),
				   (int)KeyCodes.WMessages.WM_KEYDOWN,
				   (int)KeyCodes.VKeys.VK_TAB, 0);
		PostMessage(MemoryHandler.GetMainWindowHandle(),
				   (int)KeyCodes.WMessages.WM_CHAR,
				   (int)KeyCodes.VKeys.VK_TAB, 0);
	}
