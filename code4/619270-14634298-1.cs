    using System;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            const uint WM_SETTEXT = 0x000C;
    
            [DllImport("user32.dll", CharSet = CharSet.Auto)]
            static extern IntPtr SendMessage(IntPtr hWnd, unit Msg, 
                IntPtr wParam, string lParam);
    
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
                SendMessage(textBox1.Handle, WM_SETTEXT, IntPtr.Zero,
                  textBox1.Text + ", " + textBox1.Text);
            }
        }
    }
