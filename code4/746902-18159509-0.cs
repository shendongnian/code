    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using YMSGPro;
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                YMSGClass ym = null;
                string username = "m.mohsen1375";
                string password = "pw";
                ym.Connect(ref username, ref password);
            }
        }
    }
