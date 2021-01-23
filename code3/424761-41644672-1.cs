	using System;
	using System.Runtime.InteropServices;
	public class Temp
	{
        //Just need this
        //==============================
		static IntPtr ConsoleWindowHnd = GetForegroundWindow();
		[DllImport("user32.dll")]
		static extern IntPtr GetForegroundWindow();
		[DllImport("User32.Dll")]
		private static extern bool PostMessage(IntPtr hWnd, uint msg, int wParam, int lParam);
		const int VK_RETURN = 0x0D;
        const int WM_KEYDOWN = 0x100;
        //==============================
		public static void Main(string[] args)
		{
			System.Threading.Tasks.Task.Run(() =>
			{
				System.Threading.Thread.Sleep(2000);
                //And use like this
                //===================================================
				PostMessage(ConsoleWindowHnd, WM_KEYDOWN, VK_RETURN, 0);
                //===================================================
			});
			Console.WriteLine("Waiting");
			Console.ReadLine();
			Console.WriteLine("Waiting Done");
            Console.Write("Press any key to continue . . .");
            Console.ReadKey();
		}
	}
  
  
  
