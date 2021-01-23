    	using System;
		using System.Collections.Generic;
		using System.Text;
		using System.Runtime.InteropServices;
		namespace PanelTest
		{
			public static class win32msg
			{
				[DllImport("coredll.dll")]
				[return: MarshalAs(UnmanagedType.Bool)]
				public static extern bool PeekMessage(out NativeMessage lpMsg, IntPtr hWnd, uint wMsgFilterMin, uint wMsgFilterMax, uint wRemoveMsg);
				public enum WM : uint{
					/// <summary>
					/// Use WM_MOUSEFIRST to specify the first mouse message. Use the PeekMessage() Function.
					/// </summary>
					WM_MOUSEFIRST = 0x0200,
					/// <summary>
					/// Use WM_MOUSELAST to specify the last mouse message. Used with PeekMessage() Function.
					/// </summary>
					WM_MOUSELAST = 0x020E,
				}
				[StructLayout(LayoutKind.Sequential)]
				public struct NativeMessage
				{
					public IntPtr handle;
					public uint msg;
					public IntPtr wParam;
					public IntPtr lParam;
					public uint time;
					public System.Drawing.Point p;
				}
			}
		}
