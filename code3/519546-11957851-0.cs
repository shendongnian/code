    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Diagnostics;
    using System.Threading.Tasks;
    using System.Threading;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            private System.Windows.Forms.Timer _time = new System.Windows.Forms.Timer();
            private Task _t1 = null;
            private Task _t2 = null;
            private bool _closingFlag = false;
            public Form1()
            {
                InitializeComponent();
    
                _time.Interval = 50;
                _time.Tick += (s, e) => { 
                    textBox1.Text = DateTime.Now.ToString();
                    if (_closingFlag) Debugger.Break();
                };
    
                _time.Start();
            }
    
            private void Form1_FormClosing(object sender, FormClosingEventArgs e)
            {
                _closingFlag = true;
    
                _t1 = Task.Factory.StartNew(() => { Thread.Sleep(1000); });
                _t2 = Task.Factory.StartNew(() => { Thread.Sleep(1000); });
                
                Task.WaitAll(_t1, _t2);
            }
        }
    }
