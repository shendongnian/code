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
    
    namespace WindowsFormsApplication2
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            const uint TPM_LEFTBUTTON = 0x0000;
            const uint TPM_RETURNCMD = 0x0100;
            const uint WM_SYSCOMMAND = 0x0112;
    
            [DllImport("user32.dll")]
            static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);
    
            [DllImport("user32.dll")]
            static extern uint TrackPopupMenuEx(IntPtr hmenu, uint fuFlags, int x, int y, IntPtr hwnd, IntPtr lptpm);
    
            [return: MarshalAs(UnmanagedType.Bool)]
            [DllImport("user32.dll", SetLastError = true)]
            static extern bool PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);
    
            public static void ShowContextMenu(IntPtr appWindow, IntPtr myWindow, Point point)
            {
                IntPtr wMenu = GetSystemMenu(appWindow, false);
                // Display the menu
                uint command = TrackPopupMenuEx(wMenu,
                    TPM_LEFTBUTTON | TPM_RETURNCMD, (int)point.X, (int)point.Y, myWindow, IntPtr.Zero);
                if (command == 0)
                    return;
    
                PostMessage(appWindow, WM_SYSCOMMAND, new IntPtr(command), IntPtr.Zero);
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                ShowContextMenu(new IntPtr(<<put your target window handle here>>), this.Handle, new Point(0, 0));
            }
        }
    }
