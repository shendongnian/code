namespace MyWinFormsApp
{
	static class Program
	{
		[DllImport("kernel32.dll")]
		static extern bool AttachConsole(int dwProcessId);
		private const int ATTACH_PARENT_PROCESS = -1;
		[STAThread]
		static void Main(string[] args)
		{
			if (Environment.UserInteractive) // on Console..
			{
				// redirect console output to parent process;
				// must be before any calls to Console.WriteLine()
				AttachConsole(ATTACH_PARENT_PROCESS);
				// to demonstrate where the console output is going
				int argCount = args == null ? 0 : args.Length;
				Console.WriteLine("nYou specified {0} arguments:", argCount);
				for (int i = 0; i < argCount; i++)
				{
					Console.WriteLine("  {0}", args[i]);
				}
			}
			else
			{
				// launch the WinForms application like normal
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				Application.Run(new Form1());
			}
		}
	}
}
(or write a console app from scratch)
