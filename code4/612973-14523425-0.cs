    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    
    namespace WindowsFormsApplication37
    {
        public partial class Form1 : Form
        {
            [DllImport("user32.dll", SetLastError = true)]
            static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);
    
            [DllImport("user32.dll", ExactSpelling = true, CharSet = CharSet.Auto)]
            public static extern IntPtr GetParent(IntPtr hWnd);
    
            Form2 form2 = null;
            IntPtr parent = IntPtr.Zero;
    
            public Form1()
            {
                InitializeComponent();
            }
    
            private void formShowDialogBtn_Click(object sender, EventArgs e)
            {
                timer1.Start();
    
                // This form gets closed when the WindowState of Form1 is set to minimized in timer1_Tick
                form2 = new Form2();
                form2.ShowDialog();
            }
    
            private void timer1_Tick(object sender, EventArgs e)
            {
                WindowState = FormWindowState.Minimized;
                timer1.Stop();
            }
    
            private void Form1_Resize(object sender, EventArgs e)
            {
                if (this.WindowState == FormWindowState.Minimized)
                {
                    this.parent = GetParent(form2.Handle);
                    SetParent(form2.Handle, IntPtr.Zero);
                    form2.Hide();
                }
                else
                {
                    SetParent(form2.Handle, this.parent);
                    form2.ShowDialog();
                }
            }
        }
    }
