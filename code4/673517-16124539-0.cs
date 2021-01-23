    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;
    
    namespace WindowsApplication1
    {
        public partial class Form1 : Form
        {
            int dy = 0;
            public Form1()
            {
                InitializeComponent();
                //i add a panel to top form
                //( for simulating your caption bar) and get its height
                dy = panel1.Height; //for yours its your caption bar height
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                //adding button control between form top and panel end area
                //( simulate in your caption bar )
                Button btn = new Button();
                btn.Location = new Point(panel1.Location.X+40,panel1.Location.Y+10);
                btn.Text = "Salam";
                this.Controls.Add(btn);
            }
            //in control added event i add dy ( height of ignored area) to control Location
            private void Form1_ControlAdded(object sender, ControlEventArgs e)
            {
                e.Control.Location = new Point(e.Control.Location.X, e.Control.Location.Y + dy);
            }
    
            private void button2_Click(object sender, EventArgs e)
            {
                this.Close();
            }
        }
    }
