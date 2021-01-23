    	class Program
		{
			[DllImport("User32.Dll", EntryPoint = "PostMessageA")]
			private static extern bool PostMessage(IntPtr hWnd, uint msg, int wParam, int lParam);
	
			const int VK_RETURN = 0x0D;
			const int WM_KEYDOWN = 0x100;
	
			static void Main(string[] args)
			{
				Console.Write("Switch focus to another window now to verify this works in a background process.\n");
	
				ThreadPool.QueueUserWorkItem((o) =>
				{
					Thread.Sleep(4000);
	
					var hWnd = System.Diagnostics.Process.GetCurrentProcess().MainWindowHandle;
					PostMessage(hWnd, WM_KEYDOWN, VK_RETURN, 0);
				});
	
				Console.ReadLine();
	
				Console.Write("ReadLine() successfully aborted by background thread.\n");
				Console.Write("[any key to exit]");
				Console.ReadKey();
			}
		}
