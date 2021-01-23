    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Windows.Forms;
    using System.Drawing;
    
    namespace WindowsFormsApplication4
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                this.Size = new System.Drawing.Size(800, 600);
                this.TopMost = true;
                this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
                Func<bool> run = () =>
                    Window.Find(hwnd =>
                    {
                        var cn = Window.GetClassName(hwnd);
                        var res = (cn == "CabinetWClass");
                        if (res)
                        {
                            this.Controls.Clear();
                            Window.SetParent(hwnd, this.Handle);
                            Window.SetWindowPos(hwnd, new IntPtr(0), -8, -30, this.Width + 10, this.Height + 37, 0x0040);
                        }
                        return res;
                    });
    
                new Button { Parent = this, Text = "Start" }
                    .Click += (s, e) =>
                        {
                            if (run() == false)
                                MessageBox.Show("Open Explorer");
                        };
            }
        }
    
        public static class Window
        {
            public static bool Find(Func<IntPtr, bool> fn)
            {
                return EnumWindows((hwnd, lp) => !fn(hwnd), 0) == 0;
            }
            public static string GetClassName(IntPtr hwnd)
            {
                var sb = new StringBuilder(1024);
                GetClassName(hwnd, sb, sb.Capacity);
                return sb.ToString();
            }
            public static uint GetProcessId(IntPtr hwnd)     // {0:X8}
            {
                uint pid;
                GetWindowThreadProcessId(hwnd, out pid);
                return pid;
            }
            public static string GetText(IntPtr hwnd)
            {
                var sb = new StringBuilder(1024);
                GetWindowText(hwnd, sb, sb.Capacity);
                return sb.ToString();
            }
    
            delegate bool CallBackPtr(IntPtr hwnd, int lParam);
    
            [DllImport("user32.dll")]
            static extern int EnumWindows(CallBackPtr callPtr, int lPar);
    
            [DllImport("user32.dll")]
            static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);
    
            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);
    
            [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
            static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);
    
            [DllImport("User32", CharSet = CharSet.Auto, ExactSpelling = true)]
            public static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndParent);
    
            [DllImport("user32.dll", SetLastError = true)]
            public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int W, int H, uint uFlags);
        }
    }
