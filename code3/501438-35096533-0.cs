	using System;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Data;
	using System.Drawing;
	using System.Linq;
	using System.Runtime.InteropServices;
	using System.Text;
	using System.Threading.Tasks;
	using System.Windows.Forms;
	namespace WindowsFormsApplication1
	{
		public partial class Form1 : Form
		{
			public Form1()
			{
				InitializeComponent();
			}
			private void Form1_Load(object sender, EventArgs e)
			{
				// Open the color dialog before the form actually loads
				ColorDialogEx oColorDialog = new ColorDialogEx(this.CreateGraphics());
				oColorDialog.FullOpen = true;
				oColorDialog.ShowDialog();
			}
		}
		public class ColorDialogEx : ColorDialog
		{
			private const Int32 WM_INITDIALOG = 0x0110; // Windows Message Constant
			private Graphics oGraphics;
			private const uint GW_HWNDLAST = 1;
			private const uint GW_HWNDPREV = 3;
			private string sColorPickerText = "1-Color Picker";
			private string sBasicColorsText = "2-Basic colors:";
			private string sDefineCustomColorsButtonText = "3-Define Custom Colors >>";
			private string sOKButtonText = "4-OK";
			private string sCancelButtonText = "5-Cancel";
			private string sAddToCustomColorsButtonText = "6-Add to Custom Colors";
			private string sColorText = "7-Color";
			private string sSolidText = "|8-Solid";
			private string sHueText = "9-Hue:";
			private string sSatText = "10-Sat:";
			private string sLumText = "11-Lum:";
			private string sRedText = "12-Red:";
			private string sGreenText = "13-Green:";
			private string sBlueText = "14-Blue:";
			private string sCustomColorsText = "15-Custom colors:";
			// WinAPI definitions
			[DllImport("user32.dll", CharSet = CharSet.Auto)]
			private static extern bool SetWindowText(IntPtr hWnd, string text);
			[DllImport("user32.dll", SetLastError = true)]
			internal static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);
			[DllImport("user32.dll")]
			public static extern long GetWindowRect(int hWnd, ref Rectangle lpRect);
			[DllImport("user32.dll")]
			[return: MarshalAs(UnmanagedType.Bool)]
			static extern bool GetTitleBarInfo(IntPtr hwnd, ref TITLEBARINFO pti);
			[DllImport("user32.dll", SetLastError = true)]
			static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);
			[DllImport("user32.dll")]
			private static extern IntPtr GetDlgItem(IntPtr hDlg, int nIDDlgItem);
			[DllImport("user32.dll", SetLastError = true)]
			static extern IntPtr GetWindow(IntPtr hWnd, uint uCmd);
			[DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
			private static extern int GetClassName(IntPtr hWnd, System.Text.StringBuilder lpClassName, int nMaxCount);
			[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
			static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);
			[StructLayout(LayoutKind.Sequential)]
			struct TITLEBARINFO
			{
				public const int CCHILDREN_TITLEBAR = 5;
				public uint cbSize;
				public RECT rcTitleBar;
				[MarshalAs(UnmanagedType.ByValArray, SizeConst = CCHILDREN_TITLEBAR + 1)]
				public uint[] rgstate;
			}
			[StructLayout(LayoutKind.Sequential)]
			public struct RECT
			{
				public int Left, Top, Right, Bottom;
				public RECT(int left, int top, int right, int bottom)
				{
					Left = left;
					Top = top;
					Right = right;
					Bottom = bottom;
				}
				public RECT(System.Drawing.Rectangle r) : this(r.Left, r.Top, r.Right, r.Bottom) { }
				public int X
				{
					get { return Left; }
					set { Right -= (Left - value); Left = value; }
				}
				public int Y
				{
					get { return Top; }
					set { Bottom -= (Top - value); Top = value; }
				}
				public int Height
				{
					get { return Bottom - Top; }
					set { Bottom = value + Top; }
				}
				public int Width
				{
					get { return Right - Left; }
					set { Right = value + Left; }
				}
				public System.Drawing.Point Location
				{
					get { return new System.Drawing.Point(Left, Top); }
					set { X = value.X; Y = value.Y; }
				}
				public System.Drawing.Size Size
				{
					get { return new System.Drawing.Size(Width, Height); }
					set { Width = value.Width; Height = value.Height; }
				}
				public static implicit operator System.Drawing.Rectangle(RECT r)
				{
					return new System.Drawing.Rectangle(r.Left, r.Top, r.Width, r.Height);
				}
				public static implicit operator RECT(System.Drawing.Rectangle r)
				{
					return new RECT(r);
				}
				public static bool operator ==(RECT r1, RECT r2)
				{
					return r1.Equals(r2);
				}
				public static bool operator !=(RECT r1, RECT r2)
				{
					return !r1.Equals(r2);
				}
				public bool Equals(RECT r)
				{
					return r.Left == Left && r.Top == Top && r.Right == Right && r.Bottom == Bottom;
				}
				public override bool Equals(object obj)
				{
					if (obj is RECT)
						return Equals((RECT)obj);
					else if (obj is System.Drawing.Rectangle)
						return Equals(new RECT((System.Drawing.Rectangle)obj));
					return false;
				}
				public override int GetHashCode()
				{
					return ((System.Drawing.Rectangle)this).GetHashCode();
				}
				public override string ToString()
				{
					return string.Format(System.Globalization.CultureInfo.CurrentCulture, "{{Left={0},Top={1},Right={2},Bottom={3}}}", Left, Top, Right, Bottom);
				}
			}
			public ColorDialogEx(Graphics g)
			{
				oGraphics = g;
			}
			protected override IntPtr HookProc(IntPtr nColorDialogHandle, int msg, IntPtr wparam, IntPtr lparam)
			{
				IntPtr returnValue = base.HookProc(nColorDialogHandle, msg, wparam, lparam);
				if (msg == WM_INITDIALOG)
				{
					IntPtr[] oStaticHandleArray = new IntPtr[9];
					// Change the window title
					SetWindowText(nColorDialogHandle, sColorPickerText);
					// Get titlebar info for calculations later
					TITLEBARINFO oTITLEBARINFO = new TITLEBARINFO();
					oTITLEBARINFO.cbSize = (uint)System.Runtime.InteropServices.Marshal.SizeOf(oTITLEBARINFO);
					GetTitleBarInfo(nColorDialogHandle, ref oTITLEBARINFO);
					// Change the text of the "Basic colors:" label
					oStaticHandleArray[0] = GetDlgItem(nColorDialogHandle, 0xFFFF);
					SetWindowText(oStaticHandleArray[0], sBasicColorsText);
					
					// Change the text of the "Define Custom Colors >>" button
					SetWindowText(GetDlgItem(nColorDialogHandle, 0x2CF), sDefineCustomColorsButtonText);
					// Save the "OK" button size and new width
					Rectangle oOKButtonRect = new Rectangle();
					int nOKButtonWidth = (int)oGraphics.MeasureString(sOKButtonText, new Font("Microsoft Sans Serif", 8, FontStyle.Regular)).Width + 20;  // +20 accounts for extra +10 padding on either side
					// Find the "OK" Button
					IntPtr nChildHandle = GetDlgItem(nColorDialogHandle, 0x1);
					if (nChildHandle.ToInt32() > 0)
					{
						// The "OK" button was found
						// Now save the current size and position
						GetWindowRect(nChildHandle.ToInt32(), ref oOKButtonRect);
						// We have to subtract oOKButtonRect.X value from oOKButtonRect.Width to obtain the "real" button width (same thing with subtracting Y value from Height)
						oOKButtonRect.Width = oOKButtonRect.Width - oOKButtonRect.X;
						oOKButtonRect.Height = oOKButtonRect.Height - oOKButtonRect.Y;
						// Resize the "OK" button so that the new text fits properly
						// NOTE: I cannot be sure 100% if it is correct to use the titlebar to find the position of the button or not but the math works out in all of my tests
						MoveWindow(nChildHandle, oOKButtonRect.X - oTITLEBARINFO.rcTitleBar.X, oOKButtonRect.Y - oTITLEBARINFO.rcTitleBar.Y - oTITLEBARINFO.rcTitleBar.Height, nOKButtonWidth, oOKButtonRect.Height, true);
						// Finally, change the button text
						SetWindowText(nChildHandle, sOKButtonText);
					}
					// Find the "Cancel" Button
					nChildHandle = GetDlgItem(nColorDialogHandle, 0x2);
					if (nChildHandle.ToInt32() > 0)
					{
						// The "Cancel" button was found
						// Now get the current size and position
						Rectangle oCancelButtonRect = new Rectangle();
						GetWindowRect(nChildHandle.ToInt32(), ref oCancelButtonRect);
						// We have to subtract oCancelButtonRect.X value from oCancelButtonRect.Width to obtain the "real" button width (same thing with subtracting Y value from Height)
						oCancelButtonRect.Width = oCancelButtonRect.Width - oCancelButtonRect.X;
						oCancelButtonRect.Height = oCancelButtonRect.Height - oCancelButtonRect.Y;
						// Resize the "Cancel" button so that the new text fits properly
						// NOTE: I cannot be sure 100% if it correct to use the titlebar to find the position of the button or not but the math works out in all of my tests
						MoveWindow(nChildHandle, oOKButtonRect.X + nOKButtonWidth - oTITLEBARINFO.rcTitleBar.X + 6, oCancelButtonRect.Y - oTITLEBARINFO.rcTitleBar.Y - oTITLEBARINFO.rcTitleBar.Height, (int)oGraphics.MeasureString(sCancelButtonText, new Font("Microsoft Sans Serif", 8, FontStyle.Regular)).Width + 20, oCancelButtonRect.Height, true);
						// Finally, change the button text
						SetWindowText(nChildHandle, sCancelButtonText);
					}
					// Change the text of the "Add to Custom Colors" button
					SetWindowText(GetDlgItem(nColorDialogHandle, 0x2C8), sAddToCustomColorsButtonText);
					// Change the text of the "Color" label text
					oStaticHandleArray[1] = GetDlgItem(nColorDialogHandle, 0x2DA);
					SetWindowText(oStaticHandleArray[1], sColorText);
					// Change the text of the "Solid" label text
					oStaticHandleArray[2] = GetDlgItem(nColorDialogHandle, 0x2DB);
					SetWindowText(oStaticHandleArray[2], sSolidText);
					// Change the text of the "Hue:" label
					oStaticHandleArray[3] = GetDlgItem(nColorDialogHandle, 0x2D3);
					SetWindowText(oStaticHandleArray[3], sHueText);
					// Change the text of the "Sat:" label
					oStaticHandleArray[4] = GetDlgItem(nColorDialogHandle, 0x2D4);
					SetWindowText(oStaticHandleArray[4], sSatText);
					// Change the text of the "Lum:" label
					oStaticHandleArray[5] = GetDlgItem(nColorDialogHandle, 0x2D5);
					SetWindowText(oStaticHandleArray[5], sLumText);
					// Change the text of the "Red:" label
					oStaticHandleArray[6] = GetDlgItem(nColorDialogHandle, 0x2D6);
					SetWindowText(oStaticHandleArray[6], sRedText);
					// Change the text of the "Green:" label
					oStaticHandleArray[7] = GetDlgItem(nColorDialogHandle, 0x2D7);
					SetWindowText(oStaticHandleArray[7], sGreenText);
					// Change the text of the "Blue:" label
					oStaticHandleArray[8] = GetDlgItem(nColorDialogHandle, 0x2D8);
					SetWindowText(oStaticHandleArray[8], sBlueText);
					// Change the text of the "Custom Colors:" label
					SetCustomColorsText(nColorDialogHandle, oStaticHandleArray);
				}
				return returnValue;
			}
			private static string GetClassName(IntPtr nHandle)
			{
				// Create the stringbuilder object that is used to get the window class name from the GetClassName win api function
				System.Text.StringBuilder sClassName = new System.Text.StringBuilder(100);
				GetClassName(nHandle, sClassName, sClassName.Capacity);
				return sClassName.ToString();
			}
			private static string GetWindowText(IntPtr nHandle)
			{
				// Create the stringbuilder object that is used to get the window text from the GetWindowText win api function
				System.Text.StringBuilder sWindowText = new System.Text.StringBuilder(100);
				GetWindowText(nHandle, sWindowText, sWindowText.Capacity);
				return sWindowText.ToString();
			}
			private void SetCustomColorsText(IntPtr nHandle, IntPtr[] oStaticHandleArray)
			{
				// Find the last control based on the handle to the main window
				IntPtr nWorkingHandle = GetWindow(FindWindowEx(nHandle, IntPtr.Zero, null, null), GW_HWNDLAST);
				bool bFound = false;
				do
				{
					// Look only for "Static" controls that we have not already changed
					if (GetClassName(nWorkingHandle) == "Static" && oStaticHandleArray.Contains(nWorkingHandle) == false)
					{
						// Found a "Static" control
						// Check to see if it is the one we are looking for
						string sControlText = GetWindowText(nWorkingHandle);
						if (sControlText != "")
						{
							// Found the "Custom Colors:" label
							// Change the text of the "Custom Colors:" label
							SetWindowText(nWorkingHandle, sCustomColorsText);
							bFound = true;
						}
					}
					// Working backwards we look for the previous control
					nWorkingHandle = GetWindow(nWorkingHandle, GW_HWNDPREV);
					// Jump out of the loop when the working handle doesn't find anymore controls
					if (nWorkingHandle == IntPtr.Zero)
						break;
				} while (bFound == false);
			}
		}
	}
