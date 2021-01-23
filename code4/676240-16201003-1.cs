    		public static void show_display_devices()
		{
		    DISPLAY_DEVICE lpDisplayDevice = new DISPLAY_DEVICE(0);		// OUT
				DISPLAY_DEVICE monitor_name = new DISPLAY_DEVICE(0);		// OUT
			int devNum = 0;
			while (EnumDisplayDevices(null, devNum, ref lpDisplayDevice, 0))
		    {
				Console.WriteLine("\ndevNum =" + devNum);
				Console.WriteLine("cb =" + lpDisplayDevice.cb);
				Console.WriteLine("DeviceID =" + lpDisplayDevice.DeviceID);
				Console.WriteLine("DeviceKey =" + lpDisplayDevice.DeviceKey);
				Console.WriteLine("DeviceName =" + lpDisplayDevice.DeviceName.Trim());
				Console.WriteLine("DeviceString =" + lpDisplayDevice.DeviceString.Trim());
				// Show monitor name:
				EnumDisplayDevices( lpDisplayDevice.DeviceName, 0, ref monitor_name, 0);
				Console.WriteLine("Monitor name =" + monitor_name.DeviceString.Trim());
				++devNum;
			}
		}
		[DllImport("User32.dll")]
		private static extern bool EnumDisplayDevices(
			string lpDevice, int iDevNum,
			ref DISPLAY_DEVICE lpDisplayDevice, int dwFlags);
		[StructLayout(LayoutKind.Sequential)]
		public struct DISPLAY_DEVICE
		{
			public int cb;
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
			public string DeviceName;
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
			public string DeviceString;
			public int StateFlags;
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
			public string DeviceID;
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
			public string DeviceKey;
			public DISPLAY_DEVICE(int flags)
			{
				cb = 0;
				StateFlags = flags;
				DeviceName = new string((char)32, 32);
				DeviceString = new string((char)32, 128);
				DeviceID = new string((char)32, 128);
				DeviceKey = new string((char)32, 128);
				cb = Marshal.SizeOf(this);
			}
		}
