    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Diagnostics;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication4
    {
        public partial class Form1 : Form
        {
            private Process _process;
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                this._process = Process.Start("notepad.exe");
            }
    
            private void Form1_FormClosing(object sender, FormClosingEventArgs e)
            {
                if (this._process != null) {
                    this._process.CloseMainWindow();
                    this._process.Close();
                }
            }
        }
    }
