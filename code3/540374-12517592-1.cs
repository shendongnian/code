	[STAThread]
	static void Main()
	{
		const int ERROR_CANCELLED = 1223;
		try
		{
			Process.Start("el.exe");
			// ran el in elevated node...
		}
		catch (Win32Exception ex)
		{
			if (ex.NativeErrorCode == ERROR_CANCELLED)
			{
				// "continue" as un-elevated app.
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				Application.Run(new Form1());
			}
		}
	}
