    class SendMessage
    {
	[DllImport("user32.dll")]
    public static extern IntPtr PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);
	
	public static void sendKeystroke()
	{
		const uint WM_KEYDOWN = 0x100;
		const uint WM_KEYUP = 0x0101;
		
		IntPtr hWnd;
		string processName = "putty";
		Process[] processList = Process.GetProcesses();
		
		foreach (Process P in processList)
		{
			if (P.ProcessName.Equals(processName))
			{
				IntPtr edit = P.MainWindowHandle;
				PostMessage(edit, WM_KEYDOWN, (IntPtr)(Keys.Control), IntPtr.Zero);
				PostMessage(edit, WM_KEYDOWN, (IntPtr)(Keys.A), IntPtr.Zero);
				PostMessage(edit, WM_KEYUP, (IntPtr)(Keys.Control), IntPtr.Zero);
			}
		}							
	}
    }
