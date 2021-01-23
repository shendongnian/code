    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Resources;
    using System.Text;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication8
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
                this.Icon = Properties.Resources.icon;
            
                
            }
    
            private void button2_Click(object sender, EventArgs e)
            {
                this.Icon = Properties.Resources.image;
            }
    
            private void button3_Click(object sender, EventArgs e)
            {
                this.Icon = Properties.Resources.ICO_Logo;
            }
        }
    }
