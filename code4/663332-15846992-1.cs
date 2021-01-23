	public partial class TestClass {
		[DllImport("user32.dll")]
		static extern bool EnumWindows(EnumWindowsProc lpEnumFunc, IntPtr lParam);
		public delegate bool EnumWindowsProc(IntPtr hwnd, IntPtr lParam);
		public static void TestMethod() {
			var targetName="AcroRd32.exe";
			var processArray=(
				from process in Process.GetProcesses()
				let getModuleName=new Func<Process, String>(
					x => {
						try {
							return x.MainModule.ModuleName;
						}
						catch(Win32Exception e) {
							return default(String);
						}
					}
					)
				let moduleName=getModuleName(process)
				where null!=moduleName
				where 0==String.Compare(targetName, moduleName, true)
				select process
				).ToArray();
			EnumWindows(
				(hwnd, lParam) => {
					foreach(var process in processArray)
						if(process.MainWindowHandle==hwnd)
							return !process.CloseMainWindow();
					return true;
				},
				IntPtr.Zero
				);
		}
	}
