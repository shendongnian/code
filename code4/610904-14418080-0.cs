	using System;
	using System.Windows;
	using System.Runtime.InteropServices;
	namespace MyApp
	{
		/// <summary>
		/// Interaction logic for App.xaml
		/// </summary>
		public partial class App : Application
		{
			public App()
			{
				ConsoleVisible = true;
				DisableConsoleExit();
			}
			#region Console Window Commands
			// Show/Hide
			[DllImport("kernel32.dll")]
			static extern IntPtr GetConsoleWindow();
			[DllImport("user32.dll")]
			static extern bool ShowWindow(IntPtr hWnd, uint nCmdShow);
			const uint SW_HIDE = 0;
			const uint SW_SHOWNORMAL = 1;
			const uint SW_SHOWNOACTIVATE = 4; // Show without activating
			public static bool ConsoleVisible { get; private set; }
			public static void HideConsole()
			{
				IntPtr handle = GetConsoleWindow();
				ShowWindow(handle, SW_HIDE);
				ConsoleVisible = false;
			}
			public static void ShowConsole(bool active = true)
			{
				IntPtr handle = GetConsoleWindow();
				if (active) { ShowWindow(handle, SW_SHOWNORMAL); }
				else { ShowWindow(handle, SW_SHOWNOACTIVATE); }
				ConsoleVisible = true;
			}
			// Disable Console Exit Button
			[DllImport("user32.dll")]
			static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);
			[DllImport("user32.dll")]
			static extern IntPtr DeleteMenu(IntPtr hMenu, uint uPosition, uint uFlags);
			const uint SC_CLOSE = 0xF060;
			const uint MF_BYCOMMAND = (uint)0x00000000L;
			public static void DisableConsoleExit()
			{
				IntPtr handle = GetConsoleWindow();
				IntPtr exitButton = GetSystemMenu(handle, false);
				if (exitButton != null) DeleteMenu(exitButton, SC_CLOSE, MF_BYCOMMAND);
			}
			#endregion
		}
	}
