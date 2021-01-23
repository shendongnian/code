		using System.Runtime.InteropServices;
		using System.Windows.Forms;
		using System.Drawing;
		using System;
		using System.Collections.Generic;
		using System.Linq;
		using System.Text;
		public static partial class ConsoleHelper {
			[StructLayout(LayoutKind.Sequential)]
			public struct RECT {
				public static explicit operator Rectangle(RECT rect) {
					return new Rectangle {
						X=rect.Left,
						Y=rect.Top,
						Width=rect.Right-rect.Left,
						Height=rect.Bottom-rect.Top
					};
				}
				public int Left;
				public int Top;
				public int Right;
				public int Bottom;
			}
			[DllImport("user32.dll", SetLastError=true)]
			static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int Width, int Height, bool repaint);
			[DllImport("user32.dll", SetLastError=true)]
			static extern bool GetWindowRect(IntPtr hWnd, out RECT rect);
			[DllImport("kernel32.dll", SetLastError=true)]
			static extern IntPtr GetConsoleWindow();
			public static void CenterScreen() {
				RECT rect;
				var hWnn=ConsoleHelper.GetConsoleWindow();
				var workingArea=Screen.GetWorkingArea(Point.Empty);
				ConsoleHelper.GetWindowRect(hWnn, out rect);
				var rectangle=(Rectangle)rect;
				rectangle=
				   new Rectangle {
					   X=(workingArea.Width-rectangle.Width)/2,
					   Y=(workingArea.Height-rectangle.Height)/2,
					   Width=rectangle.Width,
					   Height=rectangle.Height
				   };
				ConsoleHelper.MoveWindow(
					hWnn,
					rectangle.Left, rectangle.Top, rectangle.Width, rectangle.Height,
					true
					);
			}
		}
