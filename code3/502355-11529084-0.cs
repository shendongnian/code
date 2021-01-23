using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
namespace WindowInfo
{
    public partial class CurrentWindow : Form
    {
        Rectangle GDIrect = new Rectangle(0, 0, 100, 100);
        [DllImport("user32.dll")]
        public static extern IntPtr WindowFromPoint(Point lpPoint);
        [DllImport("user32.dll")]
        public static extern bool GetCursorPos(out Point lpPoint);
        [DllImport("user32.dll")]
        private static extern IntPtr GetWindowRect(IntPtr hWnd, ref Rect rect);
        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();
        [StructLayout(LayoutKind.Sequential)]
        public struct Rect
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }
        public CurrentWindow()
        {
            InitializeComponent();
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams baseParams = base.CreateParams;
                baseParams.ExStyle |= (int)(
                  0x00080000 |
                  0x08000000 |
                  0x00000080 |
                  0x00000020
                  );
                return baseParams;
            }
        }
        public static IntPtr GetWindowUnderCursor()
        {
            Point ptCursor = new Point();
            GetCursorPos(out ptCursor);
            return WindowFromPoint(ptCursor);
        }
        public Bitmap CaptureScreen()
        {
            var result = new Bitmap(this.DisplayRectangle.Width, this.DisplayRectangle.Height);
            using (var g = Graphics.FromImage(result))
            {
                g.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, this.DisplayRectangle.Size);
            }
            return result;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            IntPtr windowHandle = GetWindowUnderCursor();
            Rect rect = new Rect();
            GetWindowRect(windowHandle, ref rect);
            GDIrect = new Rectangle(rect.Left, rect.Top, rect.Right - rect.Left, rect.Bottom - rect.Top);
            this.Location = new Point(GDIrect.Left, GDIrect.Top);
            this.Size = GDIrect.Size;
            this.Activate();
        }
        private void CurrentWindow_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'c')
            {
                this.Visible = false;
                Bitmap bmp = CaptureScreen();
                bmp.Save(Application.StartupPath + "\\example.png");
                this.Visible = true;
            }
            else if (e.KeyChar == 'x')
            {
                this.Close();
            }
        }
    }
}
Maybe something will be helpful good luck.
  [1]: http://www.codeproject.com/Articles/6362/Global-System-Hooks-in-NET
  [2]: http://i.stack.imgur.com/8fPbc.png
