    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    
    namespace automouse
    {
        public partial class Form1 : Form
        {
            public const int WM_LBUTTONDOWN = 0x0201;
            public const int WM_LBUTTONUP = 0x0202;
    
            [DllImport("user32.dll", CharSet = CharSet.Auto)]
            private static extern int SendMessage(IntPtr hWnd, int wMsg, IntPtr wParam, IntPtr lParam);
     
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                SendMessage(button2.Handle, WM_LBUTTONDOWN, IntPtr.Zero, IntPtr.Zero);
                SendMessage(button2.Handle, WM_LBUTTONUP, IntPtr.Zero, IntPtr.Zero);
            }
    
            private void button2_Click(object sender, EventArgs e)
            {
                MessageBox.Show("Button2 clicked!");
            }
        }
    }
