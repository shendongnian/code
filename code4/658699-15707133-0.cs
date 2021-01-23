    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    namespace CarPC
    {
    public partial class MainForm
    {
    #region Methods/Consts for Embedding a Window
        [DllImport("user32.dll", EntryPoint = "GetWindowThreadProcessId", SetLastError = true,
             CharSet = CharSet.Unicode, ExactSpelling = true,
             CallingConvention = CallingConvention.StdCall)]
        private static extern long GetWindowThreadProcessId(long hWnd, long lpdwProcessId);
        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll", SetLastError = true)]
        private static extern long SetParent(IntPtr hWndChild, IntPtr hWndNewParent);
        [DllImport("user32.dll", EntryPoint = "GetWindowLongA", SetLastError = true)]
        private static extern long GetWindowLong(IntPtr hwnd, int nIndex);
        [DllImport("user32.dll")]
        static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
        [DllImport("user32.dll", SetLastError = true)]
        private static extern long SetWindowPos(IntPtr hwnd, long hWndInsertAfter, long x, long y, long cx, long cy, long wFlags);
        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool MoveWindow(IntPtr hwnd, int x, int y, int cx, int cy, bool repaint);
        [DllImport("user32.dll", EntryPoint = "PostMessageA", SetLastError = true)]
        private static extern bool PostMessage(IntPtr hwnd, uint Msg, int wParam, int lParam);
        private const int SWP_NOOWNERZORDER = 0x200;
        private const int SWP_NOREDRAW = 0x8;
        private const int SWP_NOZORDER = 0x4;
        private const int SWP_SHOWWINDOW = 0x0040;
        private const int WS_EX_MDICHILD = 0x40;
        private const int SWP_FRAMECHANGED = 0x20;
        private const int SWP_NOACTIVATE = 0x10;
        private const int SWP_ASYNCWINDOWPOS = 0x4000;
        private const int SWP_NOMOVE = 0x2;
        private const int SWP_NOSIZE = 0x1;
        private const int GWL_STYLE = (-16);
        private const int WS_VISIBLE = 0x10000000;
        private const int WM_CLOSE = 0x10;
        private const int WS_CHILD = 0x40000000;
        private const int WS_MAXIMIZE = 0x01000000;
        #endregion
        #region Variables
        private Panel gpsPanel;
        private IntPtr gpsHandle;
        private Process gpsProcess = null;
        private ProcessStartInfo gpsPSI = new ProcessStartInfo();
        #endregion
        private void SetupGPSPanel()
        {
            //Panel to Contain Controls
            this.gpsPanel = new Panel();
            this.gpsPanel.Location = new Point(this.LeftBarRight, this.TopBarBottom);
            this.gpsPanel.Size = new Size(this.Size.Width - this.LeftBarRight, this.Size.Height - this.TopBarBottom);
            this.gpsPanel.Visible = false;
            gpsPSI.FileName = "notepad.exe";
            gpsPSI.Arguments = "";
            gpsPSI.WindowStyle = ProcessWindowStyle.Maximized;
            gpsProcess = System.Diagnostics.Process.Start(gpsPSI);
            gpsProcess.WaitForInputIdle();
            gpsHandle = gpsProcess.MainWindowHandle;
            SetParent(gpsHandle, this.gpsPanel.Handle);
            SetWindowLong(gpsHandle, GWL_STYLE, WS_VISIBLE + WS_MAXIMIZE);
            MoveWindow(gpsHandle, 0,0, this.gpsPanel.Width, this.gpsPanel.Height, true);
            this.Controls.Add(gpsPanel);
        }
    }
    }
