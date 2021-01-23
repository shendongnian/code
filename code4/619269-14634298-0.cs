    using System;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication10
    {
        public partial class Form1 : Form
        {
            const uint WM_SETTEXT = 0x000C;
    
            [DllImport("user32.dll", CharSet = CharSet.Auto)]
            static extern IntPtr SendMessage(IntPtr hWnd, unit Msg, 
                IntPtr wParam, IntPtr lParam);
    
            public Form1()
            {
                InitializeComponent();
            }
    
            private void textBox1_TextChanged(object sender, EventArgs e)
            {
                MessageBox.Show(textBox1.Text);
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                IntPtr text = Marshal.StringToCoTaskMemUni(textBox1.Text + ", "
                    + textBox1.Text);
                SendMessage(textBox1.Handle, WM_SETTEXT, IntPtr.Zero, text);
                Marshal.FreeCoTaskMem(text);
            }
        }
    }
